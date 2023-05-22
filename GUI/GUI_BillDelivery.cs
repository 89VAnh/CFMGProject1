using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GUI
{
    public partial class GUI_BillDelivery : Form
    {
        private BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();
        private BUS_BillDetailDelivery busBillDetailDelivery = new BUS_BillDetailDelivery();
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Customer busCustomer = new BUS_Customer();
        private BUS_Product busProduct = new BUS_Product();
        private int selectedBillDetailID = 0;
        private int selectedProductID = 0;
        private int totalPrice = 0;

        public GUI_BillDelivery()
        {
            InitializeComponent();
        }

        private void AcceptPay(object sender, EventArgs e)
        {
            UpdateDgvBill();
            UpdateDgvBillDetail(0);
            txtBillID.Clear();
            txtAddress.Clear();
            cboCustomer.SelectedIndex = 0;
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                HDGiaoHang bill = new HDGiaoHang { GiamGia = "", TongTien = 0, DiaChi = txtAddress.Text };
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bill.MaKH = cboCustomer.SelectedValue.ToString();
                    busBillDelivery.Add(bill);
                    UpdateDgvBill();
                }
            }
            else MessageBox.Show("Vui lòng nhập địa chỉ!");
        }

        private void btnAddBillDetail_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (selectedProductID > 0)
                {
                    int billID = Convert.ToInt32(txtBillID.Text);
                    if (busBillDetailDelivery.Add(billID, selectedProductID, (int)numAmount.Value, txtNote.Text))
                    {
                        MessageBox.Show($"Đã thêm vào hoá đơn {billID} : {(int)numAmount.Value} {busProduct.GetProductName(selectedProductID)}");
                        UpdateDgvBillDetail(billID);
                    }
                    else MessageBox.Show("Mã đơn không hợp lệ");
                }
                else MessageBox.Show("Vui lòng chọn món!");
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void btnDelBill_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busBillDelivery.Delete(Convert.ToInt32(txtBillID.Text)))
                    {
                        UpdateDgvBill();
                        MessageBox.Show("Xoá thành công!");
                    }
                }
                else MessageBox.Show("Mã hoá đơn không hợp lệ!");
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void btnDelBillDetail_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (selectedBillDetailID > 0)
                {
                    int billID = Convert.ToInt32(txtBillID.Text);
                    if (busBillDetailDelivery.Delete(billID))
                    {
                        UpdateDgvBillDetail(billID);
                    }
                }
                else MessageBox.Show("Vui lòng chọn món!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (dgvBillDelivery.SelectedRows.Count > 0)
                {
                    int billID = Convert.ToInt32(txtBillID.Text);
                    HDGiaoHang bill = busBillDelivery.GetByID(billID);
                    if (bill != null)
                    {
                        bill.GiamGia = busBillDelivery.GetDiscount(numDiscount.Value.ToString(), cboDiscountType.SelectedIndex);
                        bill.TongTien = (int)numTotalPrice.Value;
                        GUI_PayBillDelivery f = new GUI_PayBillDelivery(bill, busBillDetailDelivery.GetBillDetailsByBillID(bill.Ma).ToList(), totalPrice, AcceptPay);
                        f.ShowDialog();
                    }
                    else MessageBox.Show("Vui lòng chọn hoá đơn");
                }
                else MessageBox.Show("Hoá đơn chưa có món nào! Vui lòng chọn thêm món");
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgvProduct(busProduct.SearchProductsByName(txtSearch.Text));
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBillID.Text))
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HDGiaoHang bill = busBillDelivery.GetByID(Convert.ToInt32(txtBillID.Text));
                    bill.MaKH = cboCustomer.SelectedValue.ToString();
                    bill.DiaChi = txtAddress.Text;

                    if (busBillDelivery.Update(bill))
                    {
                        MessageBox.Show("Sửa thành công!");
                        UpdateDgvBill();
                    }
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
                        CTHDGiaoHang bd = busBillDetailDelivery.GetByID(selectedBillDetailID);
                        bd.SoLuong = (int)numAmount.Value;
                        bd.GhiChu = txtNote.Text;
                        if (busBillDetailDelivery.Update(bd))
                        {
                            UpdateDgvBillDetail(Convert.ToInt32(txtBillID.Text));
                            MessageBox.Show("Sửa thành công");
                        }
                        else MessageBox.Show("Hoá đơn được chọn không hợp lệ");
                    }
                    else MessageBox.Show("Vui lòng chọn món!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
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
            try
            {
                selectedProductID = (int)cboProduct.SelectedValue;
            }
            catch { }
        }

        private void dgvBillDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = (int)dgvBillDelivery[0, e.RowIndex].Value;
                txtBillID.Text = id.ToString();
                cboCustomer.SelectedValue = dgvBillDelivery[3, e.RowIndex].Value.ToString();
                txtAddress.Text = dgvBillDelivery[4, e.RowIndex].Value.ToString();
                UpdateDgvBillDetail(id);
            }
            catch { }
        }

        private void dgvBillDetailDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedBillDetailID = (int)dgvBillDetailDelivery[0, e.RowIndex].Value;
                txtNote.Text = dgvBillDetailDelivery[5, e.RowIndex].Value.ToString();
                numAmount.Value = (int)dgvBillDetailDelivery[2, e.RowIndex].Value;
                cboProduct.SelectedValue = selectedProductID;
            }
            catch { }
        }

        private void dgvBillDetailDelivery_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvBillDetailDelivery.Rows.Count == 0)
            {
                numTotalPrice.Value = 0;
                totalPrice = 0;
            }
            else
                try
                {
                    int sum = 0;
                    foreach (DataGridViewRow r in dgvBillDetailDelivery.Rows)
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

        private void Discount()
        {
            numTotalPrice.Value = Tools.Discount(totalPrice, (int)numDiscount.Value, cboDiscountType.SelectedIndex);
        }

        private void GUI_BillDelivery_Load(object sender, EventArgs e)
        {
            // cboCategoryProduct
            cboCategoryProduct.DataSource = busCategoryProduct.GetAll();
            cboCategoryProduct.ValueMember = "Ma";
            cboCategoryProduct.DisplayMember = "Ten";

            //cboCustomer
            cboCustomer.DataSource = busCustomer.GetAll();
            cboCustomer.ValueMember = "Ma";
            cboCustomer.DisplayMember = "Ma";

            List<SanPham> productList = busProduct.GetAll();
            UpdateDgvProduct(productList);
            cboProduct.DataSource = productList;
            cboProduct.ValueMember = "Ma";
            cboProduct.DisplayMember = "Ten";

            UpdateDgvBill();

            dgvProduct.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDelivery.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDetailDelivery.DefaultCellStyle.Font = new Font("SegoeUI", 10);
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            Discount();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void UpdateDgvBill()
        {
            dgvBillDelivery.DataSource = busBillDelivery.GetBillDeliveriesUnPaid().Select(x => new { x.Ma, x.GiamGia, x.TongTien, x.MaKH, x.DiaChi }).ToList();
        }

        private void UpdateDgvBillDetail(int billID)
        {
            dgvBillDetailDelivery.DataSource = busBillDetailDelivery.GetBillDetailsByBillID(billID).Select(b =>
            new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, ThanhTien = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();
        }

        private void UpdateDgvProduct(List<SanPham> products)
        {
            dgvProduct.DataSource = products.Select(p => new { p.Ma, p.Ten, p.DonGia, CategoryName = p.DanhMucSanPham.Ten }).ToList();
        }
    }
}