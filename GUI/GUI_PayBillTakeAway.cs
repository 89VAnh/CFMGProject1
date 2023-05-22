using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GUI
{
    public partial class GUI_PayBillTakeAway : Form
    {
        private EventHandler _AcceptPay;
        private HDTaiQuan _bill;
        private List<CTHDTaiQuan> _billDetails;
        private int _totalPrice;
        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();

        public GUI_PayBillTakeAway()
        {
            InitializeComponent();
        }

        public GUI_PayBillTakeAway(HDTaiQuan bill, List<CTHDTaiQuan> billDetails, int totalPrice, EventHandler AcceptPay)
        {
            InitializeComponent();

            lblTime.Text = DateTime.Now.ToString();

            BUS_Staff busStaff = new BUS_Staff();
            bill.NhanVien = busStaff.GetByID(bill.MaNV);
            lblStaff.Text = bill.MaNV;

            BUS_Customer busCustomer = new BUS_Customer();
            bill.KhachHang = busCustomer.GetByID(bill.MaKH);
            lblCustomer.Text = bill.MaKH;

            lblTotalPrice.Text = Tools.ConvertToCurrency(totalPrice);

            lblDiscount.Text = bill.GiamGia;

            lblPriceAfterDiscount.Text = Tools.ConvertToCurrency(bill.TongTien);

            dgvBillAtShop.DataSource = billDetails.Select(b => new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, Total = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();

            bill.ThoiGianRa = DateTime.Now;

            _AcceptPay = AcceptPay;
            _totalPrice = totalPrice;
            _billDetails = billDetails;
            _bill = bill;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hoàn tất thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busBillAtShop.Update(_bill))
                {
                    _AcceptPay(sender, e);
                    MessageBox.Show("Thanh toán thành công!");
                    this.Close();
                }
                else MessageBox.Show("Mã hoá đơn không hợp lệ!");
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
            saveFileDialog.Title = "Lưu thông tin hoá đơn mang về";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busBillAtShop.ExportBillTakeAwayToWord(_bill, _billDetails, _totalPrice, @"Template\HDMangVe_Template.docx", saveFileDialog.FileName);
                    Process.Start(saveFileDialog.FileName);

                    if (busBillAtShop.Update(_bill))
                    {
                        MessageBox.Show("Thanh toán thành công!");
                        _AcceptPay(sender, e);
                        this.Close();
                    }
                    else MessageBox.Show("Mã hoá đơn không hợp lệ!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }
    }
}