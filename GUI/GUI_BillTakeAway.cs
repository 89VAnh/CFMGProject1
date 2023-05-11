using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_BillTakeAway : Form
    {
        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();

        private BUS_Staff busStaff = new BUS_Staff();
        private BUS_BillDetailAtShop busBillDetailAtShop = new BUS_BillDetailAtShop();
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Customer busCustomer = new BUS_Customer();

        private int selectedProductID = 0;
        private int totalPrice = 0;
        private int selectedBillDetailID = 0;

        public GUI_BillTakeAway()
        {
            InitializeComponent();
        }

        private void UpdateDgvProduct(List<SanPham> products)
        {
            dgvProduct.DataSource = products.Select(p => new { p.Ma, p.Ten, p.DonGia, CategoryName = p.DanhMucSanPham.Ten }).ToList();
        }

        private void UpdateDgvBill()
        {
            dgvBillTakeAway.DataSource = busBillAtShop.GetBillTakeAwayUnPaid().Select(x => new { x.Ma, x.MaKH, x.MaNV, x.GiamGia, x.TongTien, x.ThoiGianVao }).ToList();
        }

        private void UpdateDgvBillDetail(int billID)
        {
            dgvBillDetailTakeAway.DataSource = busBillDetailAtShop.GetBillDetailByBillID(billID).Select(b =>
            new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, ThanhTien = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();
        }

        private void GUI_BillTakeAway_Load(object sender, EventArgs e)
        {
            cboStaff.DataSource = busStaff.GetAll();
            cboStaff.ValueMember = "Ma";
            cboStaff.DisplayMember = "Ma";

            cboCustomer.DataSource = busCustomer.GetAll();
            cboCustomer.ValueMember = "Ma";
            cboCustomer.DisplayMember = "Ma";

            cboCategoryProduct.DataSource = busCategoryProduct.GetAll();
            cboCategoryProduct.ValueMember = "Ma";
            cboCategoryProduct.DisplayMember = "Ten";

            List<SanPham> productList = busProduct.GetAll();
            UpdateDgvProduct(productList);
            cboProduct.DataSource = productList;
            cboProduct.ValueMember = "Ma";
            cboProduct.DisplayMember = "Ten";

            UpdateDgvBill();

            dgvProduct.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillTakeAway.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDetailTakeAway.DefaultCellStyle.Font = new Font("SegoeUI", 10);
        }

        private void cboCategoryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<SanPham> products = busProduct.SearchProductsByCategory(Convert.ToInt32(cboCategoryProduct.SelectedValue)).ToList();
                cboProduct.DataSource = products;
                cboProduct.ValueMember = "Ma";
                cboProduct.DisplayMember = "Ten";
                UpdateDgvProduct(products);
            }
            catch { };
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
            try
            {
                selectedProductID = (int)cboProduct.SelectedValue;
            }
            catch { }
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

        private void dgvBillTakeAway_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = (int)dgvBillTakeAway[0, e.RowIndex].Value;
                txtBillID.Text = id.ToString();
                cboCustomer.SelectedValue = dgvBillTakeAway[1, e.RowIndex].Value.ToString();
                cboStaff.SelectedValue = dgvBillTakeAway[2, e.RowIndex].Value.ToString();
                UpdateDgvBillDetail(id);
            }
            catch { }
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if (cboStaff.SelectedValue != null)
            {
                HDTaiQuan bill = new HDTaiQuan { Ma = busBillAtShop.GetNewID(), MaNV = cboStaff.SelectedValue.ToString(), GiamGia = "", TongTien = 0, ThoiGianVao = DateTime.Now };
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bill.MaKH = cboCustomer.SelectedValue.ToString();
                    busBillAtShop.Add(bill);
                    UpdateDgvBill();
                }
            }
            else MessageBox.Show("Vui lòng chọn mã nhân viên!");
        }

        private void btnDelBill_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBillID.Text);
            if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busBillAtShop.Delete(id))
                {
                    UpdateDgvBill();
                    MessageBox.Show("Xoá thành công!");
                }
                else MessageBox.Show("Mã hoá đơn không hợp lệ!");
            }
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtBillID.Text);

                HDTaiQuan bill = busBillAtShop.GetByID(id);
                bill.MaKH = cboCustomer.SelectedValue.ToString();
                bill.MaNV = cboStaff.SelectedValue.ToString();
                if (busBillAtShop.Update(bill))
                {
                    MessageBox.Show("Sửa thành công!");
                    UpdateDgvBill();
                }
                else MessageBox.Show("Mã hoá đơn không hợp lệ");
            }
        }

        private void dgvBillDetailTakeAway_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBillDetailID = (int)dgvBillDetailTakeAway[0, e.RowIndex].Value;
            txtNote.Text = dgvBillDetailTakeAway[5, e.RowIndex].Value.ToString();
            numAmount.Value = (int)dgvBillDetailTakeAway[2, e.RowIndex].Value;
            cboProduct.SelectedValue = selectedProductID;
        }

        private void dgvBillDetailTakeAway_DataSourceChanged(object sender, EventArgs e)
        {
            numDiscount.Value = 0;
            if (dgvBillDetailTakeAway.Rows.Count == 0)
            {
                numTotalPrice.Value = 0;
                totalPrice = 0;
            }
            else
                try
                {
                    int sum = 0;
                    foreach (DataGridViewRow r in dgvBillDetailTakeAway.Rows)
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
            selectedProductID = (int)dgvProduct[1, e.RowIndex].Value;
            txtNote.Clear();
            numAmount.Value = 1;
            cboProduct.SelectedValue = selectedProductID;
        }

        private void btnAddBillDetail_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (selectedProductID > 0)
                {
                    int billID = Convert.ToInt32(txtBillID.Text);
                    HDTaiQuan b = busBillAtShop.GetByID(billID);
                    if (b != null)
                    {
                        busBillDetailAtShop.Add(b, null, selectedProductID, (int)numAmount.Value, txtNote.Text);
                        MessageBox.Show($"Đã thêm vào hoá đơn {billID} : {(int)numAmount.Value} {busProduct.GetProductName(selectedProductID)}");

                        UpdateDgvBillDetail(billID);
                    }
                    else
                        MessageBox.Show("Mã hoá đơn không hợp lệ");
                }
                else MessageBox.Show("Vui lòng chọn món!");
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void btnDelBillDetail_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (selectedBillDetailID > 0)
                {
                    if (busBillDetailAtShop.Delete(selectedBillDetailID))
                    {
                        UpdateDgvBillDetail(Convert.ToInt32(txtBillID.Text));
                    }
                    else MessageBox.Show("Vui lòng chọn món!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Mã hoá đơn không hợp lệ!");
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void btnUpdateBillDetail_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
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
                            UpdateDgvBillDetail(Convert.ToInt32(txtBillID.Text));
                            MessageBox.Show("Sửa thành công");
                        }
                        else MessageBox.Show("Mã hoá đơn không hợp lệ!");
                    }
                }
                else MessageBox.Show("Vui lòng chọn món!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void AcceptPay(object sender, EventArgs e)
        {
            UpdateDgvBill();
            UpdateDgvBillDetail(0);
            txtBillID.Clear();
            cboStaff.SelectedValue = "";
            cboCustomer.SelectedIndex = 0;
        }

        private string GetDiscount()
        {
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
            return discount;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                int billID = Convert.ToInt32(txtBillID.Text);
                HDTaiQuan bill = busBillAtShop.GetByID(billID);
                if (bill != null)
                {
                    bill.GiamGia = GetDiscount();
                    bill.TongTien = (int)numTotalPrice.Value;
                    GUI_PayBillTakeAway f = new GUI_PayBillTakeAway(bill, busBillDetailAtShop.GetBillDetailByBillID(bill.Ma), totalPrice, AcceptPay);
                    f.ShowDialog();
                }
                else MessageBox.Show("Hoá đơn được chọn không hợp lệ");
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }
    }
}