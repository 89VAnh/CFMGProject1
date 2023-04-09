using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_BillDelivery : Form
    {
        BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();
        BUS_BillDetailDelivery busBillDetailDelivery = new BUS_BillDetailDelivery();
        BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        BUS_Product busProduct = new BUS_Product();
        BUS_Customer busCustomer = new BUS_Customer();

        List<SanPham> productList = new List<SanPham>();
        List<HDGiaoHang> billDeliveries = new List<HDGiaoHang>();
        List<CTHDGiaoHang> billDetailDeliveries = new List<CTHDGiaoHang>();
        List<KhachHang> customers = new List<KhachHang>();

        int selectedProductID = 0;
        int totalPrice = 0;
        int selectedCustomerID = -1;
        int selectedBillDetailDelivery = 0;

        public GUI_BillDelivery()
        {
            InitializeComponent();
        }

        private void UpdateDgvProduct(List<SanPham> products)
        {
            dgvProduct.DataSource = products.Select(p => new { p.Ma, p.Ten, p.DonGia, CategoryName = p.DanhMucSanPham.Ten }).ToList();
        }

        private void UpdateDgvBill()
        {
            dgvBillDelivery.DataSource = billDeliveries.Select(x => new { x.Ma, x.GiamGia, x.TongTien, x.MaKH, x.DiaChi }).ToList();
        }
        private void UpdateDgvBillDetail(int billID)
        {
            dgvBillDetailDelivery.DataSource = billDetailDeliveries.Where(x => x.MaHD == billID).Select(b =>
            new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, ThanhTien = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();
        }
        private void GUI_BillDelivery_Load(object sender, EventArgs e)
        {
            // cboCategoryProduct
            cboCategoryProduct.DataSource = busCategoryProduct.GetCategoryProducts();
            cboCategoryProduct.ValueMember = "Ma";
            cboCategoryProduct.DisplayMember = "Ten";

            productList = busProduct.GetProducts();
            UpdateDgvProduct(productList);
            cboProduct.DataSource = productList;
            cboProduct.ValueMember = "Ma";
            cboProduct.DisplayMember = "Ten";

            billDeliveries = busBillDelivery.GetBillDeliveriesUnPaid();
            UpdateDgvBill();

            customers = busCustomer.GetCustomers();

            billDetailDeliveries = busBillDetailDelivery.GetBillDetailDeliveries();

            dgvProduct.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDelivery.DefaultCellStyle.Font = new Font("SegoeUI", 10);
            dgvBillDetailDelivery.DefaultCellStyle.Font = new Font("SegoeUI", 10);
        }

        private void cboCategoryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<SanPham> products = productList.Where(f => f.MaDM == Convert.ToInt32(cboCategoryProduct.SelectedValue)).ToList();
                cboProduct.DataSource = products;
                cboProduct.ValueMember = "Ma";
                cboProduct.DisplayMember = "Ten";
                UpdateDgvProduct(products);
            }
            catch { };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgvProduct(productList.Where(f => f.Ten.ToLower().Contains(txtSearch.Text)).ToList());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProductID = (int)cboProduct.SelectedValue;
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
        private bool CheckCustomerID()
        {
            string text = txtCustomer.Text;
            if (String.IsNullOrWhiteSpace(text))
            {
                selectedCustomerID = -1;
                return true;
            }
            if (Int32.TryParse(text, out selectedCustomerID))
            {
                if (customers.SingleOrDefault(x => x.Ma == selectedCustomerID) != null)
                {
                    return true;
                }
            }
            selectedCustomerID = -1;
            return false;
        }
        private void dgvBillDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = (int)dgvBillDelivery[0, e.RowIndex].Value;
                txtBillID.Text = id.ToString();

                if (dgvBillDelivery[3, e.RowIndex].Value == null)
                    txtCustomer.Text = "";
                else
                    txtCustomer.Text = dgvBillDelivery[3, e.RowIndex].Value.ToString();
                txtAddress.Text = dgvBillDelivery[4, e.RowIndex].Value.ToString();
                UpdateDgvBillDetail(id);
            }
            catch { }
        }
        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                HDGiaoHang bill = new HDGiaoHang { GiamGia = "", TongTien = 0, DiaChi = txtAddress.Text };
                if (CheckCustomerID())
                {
                    if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (selectedCustomerID > 0)
                            bill.MaKH = selectedCustomerID;
                        busBillDelivery.Add(bill);
                        billDeliveries.Add(bill);
                        UpdateDgvBill();
                    }
                }
                else MessageBox.Show("Mã khách hàng không hợp lệ!");
            }
            else MessageBox.Show("Vui lòng nhập địa chỉ!");
        }

        private void btnDelBill_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBillID.Text);
            HDGiaoHang bill = billDeliveries.SingleOrDefault(x => x.Ma == id);
            if (bill != null)
            {
                if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busBillDelivery.Delete(bill);
                    billDeliveries.Remove(bill);
                    UpdateDgvBill();
                    MessageBox.Show("Xoá thành công!");
                }
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBillID.Text);
            HDGiaoHang bill = billDeliveries.SingleOrDefault(x => x.Ma == id);
            if (bill != null)
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busBillDelivery.Update(bill);
                    MessageBox.Show("Sửa thành công!");
                    GUI_BillDelivery_Load(sender, e);
                }
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");
        }

        private void dgvBillDetailDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBillDetailDelivery = (int)dgvBillDetailDelivery[0, e.RowIndex].Value;
            txtNote.Text = dgvBillDetailDelivery[5, e.RowIndex].Value.ToString();
            numAmount.Value = (int)dgvBillDetailDelivery[2, e.RowIndex].Value;
            cboProduct.SelectedValue = selectedProductID;
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
        private void btnAddBillDetail_Click(object sender, EventArgs e)
        {
            int billID = Convert.ToInt32(txtBillID.Text);
            if (billDeliveries.SingleOrDefault(x => x.Ma == billID) != null)
                if (selectedProductID > 0)
                {
                    CTHDGiaoHang newBillDetail = new CTHDGiaoHang { Ma = busBillDetailDelivery.GetNewID(), MaHD = billID, MaSP = selectedProductID, SoLuong = (int)numAmount.Value, GhiChu = txtNote.Text };

                    MessageBox.Show($"Đã thêm vào hoá đơn {billID} : {newBillDetail.SoLuong} {productList.SingleOrDefault(x => x.Ma == newBillDetail.MaSP).Ten}");

                    CTHDGiaoHang billDetailDelivery = billDetailDeliveries.SingleOrDefault(x => x.MaHD == newBillDetail.MaHD && x.MaSP == newBillDetail.MaSP);
                    if (billDetailDelivery == null)
                    {
                        busBillDetailDelivery.Add(newBillDetail);
                        billDetailDeliveries.Add(newBillDetail);
                    }
                    else
                    {
                        busBillDetailDelivery.AddAmount(billDetailDelivery, newBillDetail.SoLuong, newBillDetail.GhiChu);
                    }
                    UpdateDgvBillDetail(billID);
                }
                else MessageBox.Show("Vui lòng chọn món!");
            else MessageBox.Show("Mã đơn không hợp lệ");
        }

        private void btnDelBillDetail_Click(object sender, EventArgs e)
        {
            int billID = Convert.ToInt32(txtBillID.Text);
            if (billDeliveries.SingleOrDefault(x => x.Ma == billID) != null)
            {
                if (selectedBillDetailDelivery > 0)
                {
                    CTHDGiaoHang billDetailDelivery = billDetailDeliveries.SingleOrDefault(x => x.Ma == selectedBillDetailDelivery);
                    if (billDetailDelivery != null)
                    {
                        busBillDetailDelivery.Delete(billDetailDelivery);
                        billDetailDeliveries.Remove(billDetailDelivery);
                        UpdateDgvBillDetail(billID);
                    }
                    else MessageBox.Show("Vui lòng chọn món!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");

        }

        private void btnUpdateBillDetail_Click(object sender, EventArgs e)
        {
            int billID = Convert.ToInt32(txtBillID.Text);
            if (billDeliveries.SingleOrDefault(x => x.Ma == billID) != null)
            {
                if (selectedBillDetailDelivery > 0)
                {
                    if (MessageBox.Show("Xác nhận đổi số lượng và ghi chú", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CTHDGiaoHang bI = billDetailDeliveries.SingleOrDefault(x => x.Ma == selectedBillDetailDelivery);
                        bI.SoLuong = (int)numAmount.Value;
                        bI.GhiChu = txtNote.Text;
                        busBillDetailDelivery.Update(bI);
                        UpdateDgvBillDetail(billID);
                        MessageBox.Show("Sửa thành công");
                    }
                }
                else MessageBox.Show("Vui lòng chọn món!", "Thao tác không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");
        }

        private void AcceptPay(object sender, EventArgs e)
        {
            billDeliveries.Remove(billDeliveries.SingleOrDefault(x => x.Ma == Convert.ToInt32(txtBillID.Text)));
            UpdateDgvBill();
            txtBillID.Clear();
            txtAddress.Clear();
            txtCustomer.Clear();
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            int billID = Convert.ToInt32(txtBillID.Text);
            HDGiaoHang bill = billDeliveries.SingleOrDefault(x => x.Ma == billID);
            if (bill != null)
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
                bill.GiamGia = discount;
                bill.TongTien = (int)numTotalPrice.Value;
                GUI_PayBillDelivery f = new GUI_PayBillDelivery(bill, billDetailDeliveries.Where(x => x.MaHD == bill.Ma).ToList(), totalPrice, AcceptPay);
                f.ShowDialog();
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }
    }
}
