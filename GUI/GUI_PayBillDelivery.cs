using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_PayBillDelivery : Form
    {
        private BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();
        private HDGiaoHang b;
        private EventHandler AcceptPay;

        public GUI_PayBillDelivery()
        {
            InitializeComponent();
        }

        public GUI_PayBillDelivery(HDGiaoHang billDelivery, List<CTHDGiaoHang> billDetailDeliverys, int totalPrice, EventHandler AcceptPay)
        {
            InitializeComponent();
            var nfi = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberGroupSeparator = "."
            };
            lblTime.Text = DateTime.Now.ToString();

            if (billDelivery.MaKH == null) lblCustomer.Text = "Khách hàng mới";
            else lblCustomer.Text = billDelivery.MaKH.ToString();

            lblAddress.Text = billDelivery.DiaChi;
            lblTotalPrice.Text = totalPrice.ToString("N", nfi) + " đ";
            lblDiscount.Text = billDelivery.GiamGia;
            lblPriceAfterDiscount.Text = billDelivery.TongTien?.ToString("N", nfi) + " đ";
            dgvBillDelivery.DataSource = billDetailDeliverys.Select(b => new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, Total = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();
            this.AcceptPay = AcceptPay;

            b = billDelivery;
            b.ThoiGianNhan = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hoàn tất thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busBillDelivery.Update(b);
                MessageBox.Show("Thanh toán thành công!");
                this.AcceptPay(sender, e);
                this.Close();
            }
        }
    }
}