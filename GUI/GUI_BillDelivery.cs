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
        private BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();
        private BUS_BillDetailDelivery busBillDetailDelivery = new BUS_BillDetailDelivery();
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Customer busCustomer = new BUS_Customer();

        private List<SanPham> productList = new List<SanPham>();
        private List<HDGiaoHang> bills = new List<HDGiaoHang>();
        private List<CTHDGiaoHang> billDetails = new List<CTHDGiaoHang>();
        private List<KhachHang> customers = new List<KhachHang>();

        private int selectedProductID = 0;
        private int totalPrice = 0;
        private int selectedCustomerID = -1;
        private int selectedBillDetailID = 0;

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
            dgvBillDelivery.DataSource = bills.Select(x => new { x.Ma, x.GiamGia, x.TongTien, x.MaKH, x.DiaChi }).ToList();
        }

        private void UpdateDgvBillDetail(int billID)
        {
            dgvBillDetailDelivery.DataSource = billDetails.Where(x => x.MaHD == billID).Select(b =>
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

            bills = busBillDelivery.GetBillDeliveriesUnPaid();
            UpdateDgvBill();

            customers = busCustomer.GetCustomers();

            billDetails = busBillDetailDelivery.GetBillDetailDeliveries();

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
                        bills.Add(bill);
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
            HDGiaoHang bill = bills.SingleOrDefault(x => x.Ma == id);
            if (bill != null)
            {
                if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busBillDelivery.Delete(bill);
                    bills.Remove(bill);
                    UpdateDgvBill();
                    MessageBox.Show("Xoá thành công!");
                }
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBillID.Text);
            HDGiaoHang bill = bills.SingleOrDefault(x => x.Ma == id);
            if (bill != null)
            {
                if (CheckCustomerID())
                {
                    if (selectedCustomerID > 0)
                    {
                        bill.MaKH = selectedCustomerID;
                    }
                    bill.DiaChi = txtAddress.Text;

                    if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        busBillDelivery.Update(bill);
                        MessageBox.Show("Sửa thành công!");
                        GUI_BillDelivery_Load(sender, e);
                    }
                }
                else MessageBox.Show("Mã khách hàng không hợp lệ");
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");
        }

        private void dgvBillDetailDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBillDetailID = (int)dgvBillDetailDelivery[0, e.RowIndex].Value;
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
            if (bills.SingleOrDefault(x => x.Ma == billID) != null)
                if (selectedProductID > 0)
                {
                    CTHDGiaoHang newBillDetail = new CTHDGiaoHang { Ma = busBillDetailDelivery.GetNewID(), MaHD = billID, MaSP = selectedProductID, SoLuong = (int)numAmount.Value, GhiChu = txtNote.Text };

                    MessageBox.Show($"Đã thêm vào hoá đơn {billID} : {newBillDetail.SoLuong} {productList.SingleOrDefault(x => x.Ma == newBillDetail.MaSP).Ten}");

                    CTHDGiaoHang billDetailDelivery = billDetails.SingleOrDefault(x => x.MaHD == newBillDetail.MaHD && x.MaSP == newBillDetail.MaSP);
                    if (billDetailDelivery == null)
                    {
                        busBillDetailDelivery.Add(newBillDetail);
                        billDetails.Add(newBillDetail);
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
            if (bills.SingleOrDefault(x => x.Ma == billID) != null)
            {
                if (selectedBillDetailID > 0)
                {
                    CTHDGiaoHang billDetailDelivery = billDetails.SingleOrDefault(x => x.Ma == selectedBillDetailID);
                    if (billDetailDelivery != null)
                    {
                        busBillDetailDelivery.Delete(billDetailDelivery);
                        billDetails.Remove(billDetailDelivery);
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
            if (bills.SingleOrDefault(x => x.Ma == billID) != null)
            {
                if (selectedBillDetailID > 0)
                {
                    if (MessageBox.Show("Xác nhận đổi số lượng và ghi chú", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CTHDGiaoHang bI = billDetails.SingleOrDefault(x => x.Ma == selectedBillDetailID);
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
            bills.Remove(bills.SingleOrDefault(x => x.Ma == Convert.ToInt32(txtBillID.Text)));
            UpdateDgvBill();
            txtBillID.Clear();
            txtAddress.Clear();
            txtCustomer.Clear();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int billID = Convert.ToInt32(txtBillID.Text);
            HDGiaoHang bill = bills.SingleOrDefault(x => x.Ma == billID);
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
                GUI_PayBillDelivery f = new GUI_PayBillDelivery(bill, billDetails.Where(x => x.MaHD == bill.Ma).ToList(), totalPrice, AcceptPay);
                f.ShowDialog();
            }
            else MessageBox.Show("Vui lòng chọn hoá đơn");
        }
    }
}
