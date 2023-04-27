using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_BillAtShop : Form
    {
        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();

        private BUS_Table busTable = new BUS_Table();
        private BUS_Staff busStaff = new BUS_Staff();
        private BUS_BillDetailAtShop busBillDetailAtShop = new BUS_BillDetailAtShop();
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Customer busCustomer = new BUS_Customer();

        private int selectedProductID = 0;
        private int selectedTableID = 0;
        private int selectedBillID = 0;
        private int selectedBillDetailID = 0;
        private int totalPrice = 0;
        private string selectedStaffID = "";

        private List<SanPham> productList = new List<SanPham>();
        private List<CTHDTaiQuan> billDetails = new List<CTHDTaiQuan>();
        private List<Ban> tableList = new List<Ban>();
        private List<KhachHang> customers = new List<KhachHang>();

        public GUI_BillAtShop()
        {
            InitializeComponent();

            tableList = busTable.GetTableCoffees();
            foreach (Ban t in tableList)
            {
                Table tb = new Table(t, table_Click);
                flpTable.Controls.Add(tb);
            }
        }

        private void UpdateDgvBillDetail()
        {
            if (busBillAtShop.GetBillAtShopByTableID(selectedTableID) != null)
                selectedBillID = busBillAtShop.GetBillAtShopByTableID(selectedTableID).Ma;
            else
                selectedBillID = 0;

            dgvBillDetail.DataSource = billDetails.Where(x => x.MaHD == selectedBillID).Select(b =>
               new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, ThanhTien = b.SoLuong * b.SanPham.DonGia, b.GhiChu }
               ).ToList();
        }

        private void UpdateDgvProduct(List<SanPham> products)
        {
            dgvProduct.DataSource = products.Select(p => new { p.Ma, p.Ten, p.DonGia, TenDM = p.DanhMucSanPham.Ten }).ToList();
        }

        private void setCboChangeTableData()
        {
            cboChangeTable.DataSource = tableList.Where(x => x.TrangThai == "Trống").ToList();
            cboChangeTable.ValueMember = "Ma";
            cboChangeTable.DisplayMember = "Ten";
        }

        private void setTableStatus(int tableID, string status)
        {
            Table tb = flpTable.Controls[tableID - 1] as Table;
            if (status != tb.GetStatus())
            {
                tb.UpdateStatus(status);
                busTable.setTableStatus(tableID, status);
            }
        }

        //EventHandler
        //BillDetailAtShop
        private void GUI_BillAtShop_Load(object sender, EventArgs e)
        {
            // cboTable
            cboTable.DataSource = tableList;
            cboTable.ValueMember = "Ma";
            cboTable.DisplayMember = "Ten";
            // cboStaff
            cboStaff.DataSource = busStaff.GetStaffs();
            cboStaff.ValueMember = "Ma";
            cboStaff.DisplayMember = "Ma";
            cboStaff.SelectedValue = "";

            // cboChangeTable
            setCboChangeTableData();

            // cboCategoryProduct
            cboCategoryProduct.DataSource = busCategoryProduct.GetCategoryProducts();
            cboCategoryProduct.ValueMember = "Ma";
            cboCategoryProduct.DisplayMember = "Ten";

            //Product
            productList = busProduct.GetProducts();
            cboProduct.DataSource = productList;
            cboProduct.ValueMember = "Ma";
            cboProduct.DisplayMember = "Ten";
            UpdateDgvProduct(productList);

            billDetails = busBillDetailAtShop.GetBillDetailAtShopes();

            customers = busCustomer.GetCustomers();

            dgvProduct.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDetail.DefaultCellStyle.Font = new Font("SegoeUI", 10);
        }

        private void table_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            selectedTableID = (int)btn.Tag;
            cboTable.SelectedValue = selectedTableID;
            UpdateDgvBillDetail();
            numAmount.Value = 1;
            txtNote.Text = "";
        }

        private void dgvBillAtShop_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvBillDetail.Rows.Count == 0)
            {
                numTotalPrice.Value = 0;
                totalPrice = 0;
            }
            else
                try
                {
                    int sum = 0;
                    foreach (DataGridViewRow r in dgvBillDetail.Rows)
                    {
                        sum += (int)r.Cells[4].Value;
                    }
                    numTotalPrice.Value = sum;
                    totalPrice = sum;
                    Discount();
                }
                catch { }
        }

        private void dgvBillAtShop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBillDetailID = (int)dgvBillDetail[0, e.RowIndex].Value;
            numAmount.Value = (int)dgvBillDetail[2, e.RowIndex].Value;
            txtNote.Text = dgvBillDetail[5, e.RowIndex].Value.ToString();
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            if (selectedTableID > 0)
                if (tableList.SingleOrDefault(x => x.Ma == selectedTableID).TrangThai == "Có người")
                {
                    int newTableID = (int)cboChangeTable.SelectedValue;
                    setTableStatus(selectedTableID, "Trống");
                    setTableStatus(newTableID, "Có người");
                    busBillAtShop.SwapTable(selectedTableID, newTableID);
                    setCboChangeTableData();
                    MessageBox.Show($"Đã đổi bàn {selectedTableID} => {newTableID} thành công");
                    selectedTableID = newTableID;
                    cboTable.SelectedValue = selectedTableID;
                    UpdateDgvBillDetail();
                }
                else MessageBox.Show("Không chuyển được bàn đang trống!");
            else MessageBox.Show("Vui lòng lựa chọn bàn!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Del
        private void btnDel_Click(object sender, EventArgs e)
        {
            CTHDTaiQuan billDetailAtShop = billDetails.SingleOrDefault(x => x.Ma == selectedBillDetailID);
            if (billDetailAtShop != null)
            {
                busBillDetailAtShop.Delete(billDetailAtShop);
                billDetails.Remove(billDetailAtShop);
                UpdateDgvBillDetail();
            }
            else MessageBox.Show("Vui lòng chọn món trong chi tiết hoá đơn!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBillDetailID > 0)
            {
                if (MessageBox.Show("Xác nhận đổi số lượng và ghi chú", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CTHDTaiQuan bd = billDetails.SingleOrDefault(x => x.Ma == selectedBillDetailID);
                    bd.SoLuong = (int)numAmount.Value;
                    bd.GhiChu = txtNote.Text;
                    busBillDetailAtShop.Update(bd);
                    UpdateDgvBillDetail();
                }
            }
            else MessageBox.Show("Vui lòng chọn món trong chi tiết hoá đơn!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Product
        //Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedTableID > 0)
                if (selectedProductID > 0)
                {
                    int id;
                    HDTaiQuan billAtShop = busBillAtShop.GetBillAtShopByTableID(selectedTableID);
                    if (billAtShop == null)
                    {
                        id = busBillAtShop.GetNewID();
                        busBillAtShop.Add(new HDTaiQuan { Ma = id, MaBan = selectedTableID, ThoiGianVao = DateTime.Now, TongTien = 0 });
                        billAtShop = busBillAtShop.GetBillAtShopByTableID(selectedTableID);
                    }
                    else
                        id = billAtShop.Ma;
                    CTHDTaiQuan newBillDetail = new CTHDTaiQuan { Ma = busBillDetailAtShop.GetNewID(), MaHD = selectedBillID, MaSP = selectedProductID, SoLuong = (int)numAmount.Value, GhiChu = txtNote.Text };

                    CTHDTaiQuan billDetailAtShop = billDetails.SingleOrDefault(x => x.MaHD == newBillDetail.MaHD && x.MaSP == newBillDetail.MaSP);
                    if (billDetailAtShop == null)
                    {
                        busBillDetailAtShop.Add(newBillDetail);
                        billDetails.Add(newBillDetail);
                    }
                    else
                    {
                        busBillDetailAtShop.AddAmount(billDetailAtShop, newBillDetail.SoLuong, newBillDetail.GhiChu);
                    }

                    MessageBox.Show($"Đã thêm vào bàn {selectedTableID} : {newBillDetail.SoLuong} {productList.SingleOrDefault(x => x.Ma == newBillDetail.MaSP).Ten}");

                    selectedProductID = 0;

                    setTableStatus(selectedTableID, "Có người");
                    setCboChangeTableData();

                    UpdateDgvBillDetail();
                }
                else MessageBox.Show("Vui lòng chọn món!");
            else MessageBox.Show("Vui lòng lựa chọn bàn!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cboCategoryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<SanPham> products = productList.Where(x => x.MaDM == Convert.ToInt32(cboCategoryProduct.SelectedValue)).ToList();
                cboProduct.DataSource = products;
                cboProduct.ValueMember = "Ma";
                cboProduct.DisplayMember = "Ten";
                UpdateDgvProduct(products);
            }
            catch { };
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProductID = (int)dgvProduct[0, e.RowIndex].Value;
            txtNote.Clear();
            numAmount.Value = 1;
            cboProduct.SelectedValue = selectedProductID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgvProduct(productList.Where(x => x.Ten.ToLower().Contains(txtSearch.Text)).ToList());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProductID = (int)cboProduct.SelectedValue;
        }

        private void cboStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStaff.SelectedValue != null)
                selectedStaffID = cboStaff.SelectedValue.ToString();
            else selectedStaffID = "";
        }

        // Discount
        private void Discount()
        {
            try
            {
                int value = totalPrice,
                    discount = (int)numDiscount.Value;

                switch (cboDiscountType.SelectedIndex)
                {
                    case 0: value -= discount * 1000; break;
                    case 1: value -= value * discount / 100; break;
                    default: break;
                }
                numTotalPrice.Value = value;
            }
            catch { }
        }

        private void cboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private void AcceptPay(object sender, EventArgs e)
        {
            setTableStatus(selectedTableID, "Trống");
            setCboChangeTableData();
            UpdateDgvBillDetail();
        }

        private int customerID = 0;

        private bool CheckCustomerID()
        {
            string text = txtCustomer.Text;
            if (String.IsNullOrWhiteSpace(text))
            {
                customerID = 0;
                return true;
            }

            if (Int32.TryParse(text, out customerID))
            {
                if (customers.SingleOrDefault(x => x.Ma == customerID) != null)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (selectedTableID > 0)
            {
                if (selectedStaffID != "")
                {
                    if (CheckCustomerID())
                    {
                        Ban table = tableList.SingleOrDefault(x => x.Ma == selectedTableID);
                        if (table.TrangThai == "Có người")
                        {
                            HDTaiQuan billAtShop = busBillAtShop.GetBillAtShopByTableID(selectedTableID);
                            string discount = numDiscount.Value.ToString();
                            if (discount != "0")
                            {
                                switch (cboDiscountType.SelectedIndex)
                                {
                                    case 0: discount += "000 đ"; break;
                                    case 1: discount += " %"; break;
                                    default: break;
                                }
                            }
                            billAtShop.MaNV = selectedStaffID;
                            billAtShop.GiamGia = discount;
                            billAtShop.TongTien = (int)numTotalPrice.Value;
                            billAtShop.Ban = table;
                            if (customerID > 0)
                            {
                                billAtShop.MaKH = customerID;
                            }
                            GUI_PayBillAtShop f = new GUI_PayBillAtShop(billAtShop, billDetails.Where(x => x.MaHD == selectedBillID).ToList(), totalPrice, AcceptPay);
                            f.ShowDialog();
                        }
                        else MessageBox.Show("Mã khách hàng không tồn tại!");
                    }
                    else MessageBox.Show("Bàn được chọn đang trống!");
                }
                else MessageBox.Show("Vui lòng chọn mã nhân viên");
            }
            else MessageBox.Show("Vui lòng chọn bàn");
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedTableID = (int)cboTable.SelectedValue;
            }
            catch { }
        }
    }
}
