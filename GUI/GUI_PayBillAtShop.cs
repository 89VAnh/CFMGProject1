using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_PayBillAtShop : Form
    {
        private EventHandler _AcceptPay;

        public GUI_PayBillAtShop()
        {
            InitializeComponent();
        }

        public GUI_PayBillAtShop(HDTaiQuan bill, List<CTHDTaiQuan> billDetails, int totalPrice, EventHandler AcceptPay)
        {
            InitializeComponent();
            var nfi = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberGroupSeparator = "."
            };
            lblTable.Text = bill.Ban.Ten;
            lblTime.Text = DateTime.Now.ToString();
            lblStaff.Text = bill.MaNV;
            lblTotalPrice.Text = totalPrice.ToString("N", nfi) + " đ";
            lblDiscount.Text = bill.GiamGia;
            lblPriceAfterDiscount.Text = bill.TongTien.ToString("N", nfi) + " đ";
            if (bill.MaKH == null) lblCustomer.Text = "Khách hàng mới";
            else lblCustomer.Text = bill.MaKH.ToString();

            dgvBillAtShop.DataSource = billDetails.Select(b => new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, Total = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();
            _AcceptPay = AcceptPay;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hoàn tất thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Thanh toán thành công!");
                _AcceptPay(sender, e);
                this.Close();
            }
        }
    }
}