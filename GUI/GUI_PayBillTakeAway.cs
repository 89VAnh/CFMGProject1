using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_PayBillTakeAway : Form
    {
        BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();
        BUS_Customer busCustomer = new BUS_Customer();

        List<KhachHang> customers = new List<KhachHang>();
        HDTaiQuan b;
        EventHandler AcceptPay;

        public GUI_PayBillTakeAway()
        {
            InitializeComponent();
        }

        public GUI_PayBillTakeAway(HDTaiQuan billAtShop, List<CTHDTaiQuan> billDetailAtShops, int totalPrice, EventHandler AcceptPay)
        {
            InitializeComponent();
            var nfi = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberGroupSeparator = "."
            };

            lblTime.Text = DateTime.Now.ToString();
            lblStaff.Text = billAtShop.MaNV;
            if (billAtShop.MaKH == null) lblCustomer.Text = "Khách hàng mới";
            else lblCustomer.Text = billAtShop.MaKH.ToString();
            lblTotalPrice.Text = totalPrice.ToString("N", nfi) + " đ";
            lblDiscount.Text = billAtShop.GiamGia;
            lblPriceAfterDiscount.Text = billAtShop.TongTien.ToString("N", nfi) + " đ";
            dgvBillAtShop.DataSource = billDetailAtShops.Select(b => new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, Total = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();
            this.AcceptPay = AcceptPay;

            b = billAtShop;
            b.ThoiGianRa = DateTime.Now;
            customers = busCustomer.GetCustomers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hoàn tất thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busBillAtShop.Update(b);
                MessageBox.Show("Thanh toán thành công!");
                this.AcceptPay(sender, e);
                this.Close();
            }
        }

    }
}
