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
        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();

        private BUS_Table busTable = new BUS_Table();
        private BUS_Staff busStaff = new BUS_Staff();
        private BUS_BillDetailAtShop busBillDetailAtShop = new BUS_BillDetailAtShop();
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Customer busCustomer = new BUS_Customer();

        private int selectedProductID = 0;
        private int selectedBillID = 0;
        private int selectedBillDetailID = 0;
        private int totalPrice = 0;

        public GUI_BillAtShop()
        {
            InitializeComponent();
        }

        private void UpdateDgvBillDetail()
        {
            dgvBillDetail.DataSource = busBillDetailAtShop.GetBillDetailAtShopesInTable((int)cboTable.SelectedValue).Select(b =>
               new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, ThanhTien = b.SoLuong * b.SanPham.DonGia, b.GhiChu }
               ).ToList();
        }

        private void UpdateDgvProduct(List<SanPham> products)
        {
            dgvProduct.DataSource = products.Select(p => new { p.Ma, p.Ten, p.DonGia, TenDM = p.DanhMucSanPham.Ten }).ToList();
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

        //EventHandler
        //BillDetailAtShop
        private void GUI_BillAtShop_Load(object sender, EventArgs e)
        {
            List<Ban> tableList = busTable.GetAll();

            foreach (Ban t in tableList)
            {
                Table tb = new Table(t, table_Click);
                flpTable.Controls.Add(tb);
            }

            // cboTable
            cboTable.DataSource = tableList;
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

        private void table_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            cboTable.SelectedValue = (int)btn.Tag;
            numAmount.Value = 1;
            txtNote.Text = "";
            UpdateDgvBillDetail();
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

        //Del
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (busBillDetailAtShop.Delete(selectedBillDetailID))
            {
                UpdateDgvBillDetail();
            }
            else MessageBox.Show("Vui lòng chọn một món muốn xoá trong chi tiết hoá đơn!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Update
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

        //Product
        //Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int selectedTableID = (int)cboTable.SelectedValue;
            if (selectedProductID > 0)
            {
                busBillDetailAtShop.Add(busBillAtShop.GetBillAtShopByTableID(selectedTableID), (int)cboTable.SelectedValue, selectedProductID, (int)numAmount.Value, txtNote.Text);

                MessageBox.Show($"Đã thêm vào bàn {selectedTableID} : {(int)numAmount.Value} {busProduct.GetProductName(selectedProductID)}");

                selectedProductID = 0;

                setTableStatus(selectedTableID, "Có người");
                setCboChangeTableData();

                UpdateDgvBillDetail();
            }
            else MessageBox.Show("Vui lòng chọn món!");
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

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProductID = (int)dgvProduct[0, e.RowIndex].Value;
            txtNote.Clear();
            numAmount.Value = 1;
            cboProduct.SelectedValue = selectedProductID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgvProduct(busProduct.SearchProductsByName(txtSearch.Text));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(cboProduct.SelectedValue.ToString(), out selectedProductID);
        }

        private void Discount()
        {
            numTotalPrice.Value = Tools.Discount(totalPrice, (int)numDiscount.Value, cboDiscountType.SelectedIndex);
        }

        private void cboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private HDTaiQuan billAtShop;

        public void AcceptPay(object sender, EventArgs e)
        {
            busBillAtShop.Update(billAtShop);
            setTableStatus((int)cboTable.SelectedValue, "Trống");
            setCboChangeTableData();
            UpdateDgvBillDetail();
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
                billAtShop.MaNV = cboStaff.SelectedValue.ToString();
                billAtShop.GiamGia = discount;
                billAtShop.TongTien = (int)numTotalPrice.Value;
                billAtShop.MaBan = tableId;
                billAtShop.MaKH = cboCustomer.SelectedValue.ToString();
                billAtShop.ThoiGianRa = DateTime.Now;
                GUI_PayBillAtShop f = new GUI_PayBillAtShop(billAtShop, busBillDetailAtShop.GetBillDetailAtShopesInTable(tableId), totalPrice, AcceptPay);
                f.ShowDialog();
            }
            else MessageBox.Show("Bàn được chọn đang trống!");
        }
    }
}