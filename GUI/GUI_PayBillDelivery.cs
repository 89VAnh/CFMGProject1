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
    public partial class GUI_PayBillDelivery : Form
    {
        private EventHandler _AcceptPay;
        private HDGiaoHang _bill;
        private List<CTHDGiaoHang> _billDetails;
        private int _totalPrice;
        private BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();

        public GUI_PayBillDelivery()
        {
            InitializeComponent();
        }

        public GUI_PayBillDelivery(HDGiaoHang bill, List<CTHDGiaoHang> billDetails, int totalPrice, EventHandler AcceptPay)
        {
            InitializeComponent();

            lblTime.Text = DateTime.Now.ToString();

            BUS_Customer busCustumer = new BUS_Customer();
            bill.KhachHang = busCustumer.GetByID(bill.MaKH);
            lblCustomer.Text = bill.MaKH;

            lblAddress.Text = bill.DiaChi;

            lblTotalPrice.Text = Tools.ConvertToCurrency(totalPrice);

            lblDiscount.Text = bill.GiamGia;

            lblPriceAfterDiscount.Text = Tools.ConvertToCurrency((int)bill.TongTien);

            dgvBillDelivery.DataSource = billDetails.Select(b => new { b.Ma, b.SanPham.Ten, b.SoLuong, b.SanPham.DonGia, Total = b.SoLuong * b.SanPham.DonGia, b.GhiChu }).ToList();

            bill.ThoiGianNhan = DateTime.Now;

            _AcceptPay = AcceptPay;

            _bill = bill;
            _billDetails = billDetails;
            _totalPrice = totalPrice;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hoàn tất thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busBillDelivery.Update(_bill);
                MessageBox.Show("Thanh toán thành công!");
                _AcceptPay(sender, e);
                this.Close();
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
            saveFileDialog.Title = "Lưu thông tin hoá đơn giao hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busBillDelivery.ExportBillDeliveryToWord(_bill, _billDetails, _totalPrice, @"Template\HDGiaoHang_Template.docx", saveFileDialog.FileName);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
            busBillDelivery.Update(_bill);
            _AcceptPay(sender, e);
            this.Close();
        }
    }
}