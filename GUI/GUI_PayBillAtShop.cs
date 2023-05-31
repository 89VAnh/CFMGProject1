using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GUI
{
    public partial class GUI_PayBillAtShop : Form
    {
        private readonly BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();
        private EventHandler _AcceptPay;
        private HDTaiQuan _bill;
        private List<CTHDTaiQuan> _billDetails;
        private string _discount;
        private int _totalPrice;
        private int _totalPriceAfterDiscount;

        public GUI_PayBillAtShop()
        {
            InitializeComponent();
        }

        public GUI_PayBillAtShop(HDTaiQuan bill, List<CTHDTaiQuan> billDetails, string discount, int totalPriceAfterDiscount, int totalPrice, EventHandler AcceptPay)
        {
            InitializeComponent();

            lblTable.Text = bill.Ban.Ten;

            lblTime.Text = DateTime.Now.ToString();

            BUS_Staff busStaff = new BUS_Staff();
            bill.NhanVien = busStaff.GetByID(bill.MaNV);
            lblStaff.Text = bill.MaNV;

            BUS_Customer busCustomer = new BUS_Customer();
            bill.KhachHang = busCustomer.GetByID(bill.MaKH);
            lblCustomer.Text = bill.MaKH;

            lblTotalPrice.Text = Tools.ConvertToCurrency(totalPrice);

            lblDiscount.Text = discount;

            lblPriceAfterDiscount.Text = Tools.ConvertToCurrency(totalPriceAfterDiscount);

            dgvBillAtShop.DataSource = billDetails.Select(b => new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, Total = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();

            _AcceptPay = AcceptPay;
            _totalPrice = totalPrice;
            _billDetails = billDetails;
            _bill = bill;
            _discount = discount;
            _totalPriceAfterDiscount = totalPriceAfterDiscount;
        }

        private void AcceptPay(object sender, EventArgs e)
        {
            _bill.ThoiGianRa = DateTime.Now;
            _bill.GiamGia = _discount;
            _bill.TongTien = _totalPriceAfterDiscount;

            if (busBillAtShop.Update(_bill))
            {
                MessageBox.Show("Thanh toán thành công!");
                _AcceptPay(sender, e);
                this.Close();
            }
            else MessageBox.Show("Mã hoá đơn không hợp lệ!");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hoàn tất thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AcceptPay(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin hoá đơn tại quán";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    AcceptPay(sender, e);

                    busBillAtShop.ExportBillAtShopToWord(_bill, _billDetails, _totalPrice, @"Template\HDTaiQuan_Template.docx", saveFileDialog.FileName);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }
    }
}