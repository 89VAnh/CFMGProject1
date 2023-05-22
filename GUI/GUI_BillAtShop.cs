using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GUI
{
    public partial class GUI_BillAtShop : Form
    {
        private HDTaiQuan billAtShop;

        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();
        private BUS_BillDetailAtShop busBillDetailAtShop = new BUS_BillDetailAtShop();
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Customer busCustomer = new BUS_Customer();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Staff busStaff = new BUS_Staff();
        private BUS_Table busTable = new BUS_Table();

        private int selectedBillDetailID = 0;
        private int selectedProductID = 0;
        private int totalPrice = 0;

        public GUI_BillAtShop()
        {
            InitializeComponent();

            foreach (Ban t in busTable.GetAll())
            {
                Table tb = new Table(t, table_Click);
                flpTable.Controls.Add(tb);
            }
        }

        public void AcceptPay(object sender, EventArgs e)
        {
            setTableStatus((int)cboTable.SelectedValue, "Trống");
            UpdateDgvBillDetail();
            setCboChangeTableData();
            cboCustomer.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int selectedTableID = (int)cboTable.SelectedValue;
            if (selectedProductID > 0)
            {
                busBillDetailAtShop.Add(busBillAtShop.GetBillAtShopByTableID(selectedTableID), selectedTableID, selectedProductID, cboCustomer.SelectedValue.ToString(), cboStaff.SelectedValue.ToString(), (int)numAmount.Value, txtNote.Text);

                MessageBox.Show($"Đã thêm vào bàn {selectedTableID} : {(int)numAmount.Value} {busProduct.GetProductName(selectedProductID)}");

                selectedProductID = 0;

                setTableStatus(selectedTableID, "Có người");
                setCboChangeTableData();

                UpdateDgvBillDetail();
            }
            else MessageBox.Show("Vui lòng chọn món!");
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            if (busTable.GetTableStatus((int)cboTable.SelectedValue) == "Có người")
            {
                int selectedTableID = (int)cboTable.SelectedValue;
                int newTableID = (int)cboChangeTable.SelectedValue;
                setTableStatus(selectedTableID, "Trống");
                setTableStatus(newTableID, "Có người");

                busBillAtShop.SwapTable(selectedTableID, newTableID);

                setCboChangeTableData();
                MessageBox.Show($"Đã đổi bàn {selectedTableID} => {newTableID} thành công");
                cboTable.SelectedValue = selectedTableID;
                UpdateDgvBillDetail();
            }
            else MessageBox.Show("Không chuyển được bàn đang trống!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int tableId = (int)cboTable.SelectedValue;
            if (busTable.GetTableStatus(tableId) == "Có người")
            {
                if (dgvBillDetail.Rows.Count == 0)
                {
                    if (MessageBox.Show("Bạn có muốn huỷ hoá đơn bàn này không?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (busBillAtShop.Delete(busBillAtShop.GetBillAtShopByTableID(tableId).Ma))
                        {
                            MessageBox.Show("Xoá thành công!");
                            setTableStatus(tableId, "Trống");
                        }
                    }
                }
                else
                if (busBillDetailAtShop.Delete(selectedBillDetailID))
                {
                    UpdateDgvBillDetail();
                }
                else MessageBox.Show("Vui lòng chọn một món muốn xoá trong chi tiết hoá đơn!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Bàn này hiện không có người!");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int tableId = (int)cboTable.SelectedValue;

            if (busTable.GetTableStatus(tableId) == "Có người")
            {
                billAtShop = busBillAtShop.GetBillAtShopByTableID(tableId);
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
                if (billAtShop != null)
                {
                    if (dgvBillDetail.Rows.Count > 0)
                    {
                        billAtShop.GiamGia = discount;
                        billAtShop.TongTien = (int)numTotalPrice.Value;

                        GUI_PayBillAtShop f = new GUI_PayBillAtShop(billAtShop, busBillDetailAtShop.GetBillDetailByBillID(billAtShop.Ma), totalPrice, AcceptPay);
                        f.ShowDialog();
                    }
                    else MessageBox.Show("Bàn chưa chọn món");
                }
                else MessageBox.Show("Vui lòng chọn lại bàn");
            }
            else MessageBox.Show("Bàn được chọn đang trống!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgvProduct(busProduct.SearchProductsByName(txtSearch.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBillDetailID > 0)
            {
                if (MessageBox.Show("Xác nhận đổi số lượng và ghi chú", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CTHDTaiQuan bd = busBillDetailAtShop.GetByID(selectedBillDetailID);
                    bd.SoLuong = (int)numAmount.Value;
                    bd.GhiChu = txtNote.Text;
                    if (busBillDetailAtShop.Update(bd))
                    {
                        UpdateDgvBillDetail();
                    }
                    else MessageBox.Show("Vui lòng chọn món muốn sửa!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Vui lòng chọn chi tiết hoá đơn muốn thay đổi");
        }

        private void cboCategoryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<SanPham> products = busProduct.SearchProductsByCategory((int)cboCategoryProduct.SelectedValue);
                cboProduct.DataSource = products;
                cboProduct.ValueMember = "Ma";
                cboProduct.DisplayMember = "Ten";
                UpdateDgvProduct(products);
            }
            catch { };
        }

        private void cboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(cboProduct.SelectedValue.ToString(), out selectedProductID);
        }

        private void dgvBillAtShop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedBillDetailID = (int)dgvBillDetail[0, e.RowIndex].Value;
                numAmount.Value = (int)dgvBillDetail[2, e.RowIndex].Value;
                txtNote.Text = dgvBillDetail[5, e.RowIndex].Value.ToString();
            }
            catch { }
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

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProductID = (int)dgvProduct[0, e.RowIndex].Value;
            txtNote.Clear();
            numAmount.Value = 1;
            cboProduct.SelectedValue = selectedProductID;
        }

        private void Discount()
        {
            numTotalPrice.Value = Tools.Discount(totalPrice, (int)numDiscount.Value, cboDiscountType.SelectedIndex);
        }

        private void GUI_BillAtShop_Load(object sender, EventArgs e)
        {
            // cboTable
            cboTable.DataSource = busTable.GetAll();
            cboTable.ValueMember = "Ma";
            cboTable.DisplayMember = "Ten";
            // cboStaff
            cboStaff.DataSource = busStaff.GetAll();
            cboStaff.ValueMember = "Ma";
            cboStaff.DisplayMember = "Ma";

            // cboCustomer
            cboCustomer.DataSource = busCustomer.GetAll();
            cboCustomer.ValueMember = "Ma";
            cboCustomer.DisplayMember = "Ma";

            // cboChangeTable
            setCboChangeTableData();

            // cboCategoryProduct
            cboCategoryProduct.DataSource = busCategoryProduct.GetAll();
            cboCategoryProduct.ValueMember = "Ma";
            cboCategoryProduct.DisplayMember = "Ten";

            //Product
            List<SanPham> productList = busProduct.GetAll();
            cboProduct.DataSource = productList;
            cboProduct.ValueMember = "Ma";
            cboProduct.DisplayMember = "Ten";
            UpdateDgvProduct(productList);

            dgvProduct.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDetail.DefaultCellStyle.Font = new Font("SegoeUI", 10);
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private void setCboChangeTableData()
        {
            cboChangeTable.DataSource = busTable.GetEmptyTables();
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

        private void table_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            cboTable.SelectedValue = (int)btn.Tag;
            numAmount.Value = 1;
            txtNote.Text = "";
            UpdateDgvBillDetail();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void UpdateDgvBillDetail()
        {
            var bill = busBillAtShop.GetBillUnPaied().SingleOrDefault(x => x.MaBan == (int)cboTable.SelectedValue);
            var id = bill != null ? bill.Ma : 0;
            dgvBillDetail.DataSource = busBillDetailAtShop.GetBillDetailByBillID(id).Select(b =>
               new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, ThanhTien = b.SoLuong * b.SanPham.DonGia, b.GhiChu }
               ).ToList();
        }

        private void UpdateDgvProduct(List<SanPham> products)
        {
            dgvProduct.DataSource = products.Select(p => new { p.Ma, p.Ten, p.DonGia, TenDM = p.DanhMucSanPham.Ten }).ToList();
        }
    }
}