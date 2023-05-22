using BUS;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GUI
{
    public partial class GUI_Statistic : Form
    {
        private BUS_Bill busBill = new BUS_Bill();
        private BUS_Customer busCustomer = new BUS_Customer();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Table busTable = new BUS_Table();

        private bool isCustomDate = false;

        public GUI_Statistic()
        {
            InitializeComponent();
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            isCustomDate = !isCustomDate;
            setCusomDate(isCustomDate);
        }

        private void btnExcelBillAtShop_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value, endDate = dtpEndDate.Value;
            if (DateTime.Compare(startDate, endDate) != 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Microsoft Excel | *.xlsx";
                saveFileDialog.Title = "Lưu danh sách hoá đơn tại quán";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        busBill.ExportBillAtShopToExcel(startDate, endDate, @"Template\DanhSachHDTQ_Template.xlsx", saveFileDialog.FileName);
                        Process.Start(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void btnExcelBillDelivery_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value, endDate = dtpEndDate.Value;
            if (DateTime.Compare(startDate, endDate) != 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Microsoft Excel | *.xlsx";
                saveFileDialog.Title = "Lưu danh sách hoá đơn mang về";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        busBill.ExportBillDeliveryToExcel(startDate, endDate, @"Template\DanhSachHDGH_Template.xlsx", saveFileDialog.FileName);
                        Process.Start(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void btnExcelBillTakeAway_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value, endDate = dtpEndDate.Value;
            if (DateTime.Compare(startDate, endDate) != 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Microsoft Excel | *.xlsx";
                saveFileDialog.Title = "Lưu danh sách hoá đơn mang về";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        busBill.ExportBillTakeAwayToExcel(startDate, endDate, @"Template\DanhSachHDMV_Template.xlsx", saveFileDialog.FileName);
                        Process.Start(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadInfo();
            setCusomDate(false);
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadInfo();
            setCusomDate(false);
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadInfo();
            setCusomDate(false);
        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpStartDate.Value, dtpEndDate.Value) != 1)
            {
                LoadInfo();
            }
            else MessageBox.Show("Khoảng thời gian được chọn không hợp lệ");
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            LoadInfo();
            setCusomDate(false);
        }

        private void GUI_Statistic_Load(object sender, EventArgs e)
        {
            lblNumProducts.Text = busProduct.GetAll().Count.ToString();
            lblNumCustomers.Text = busCustomer.GetAll().Count.ToString();
            lblNumTables.Text = busTable.GetAll().Count.ToString();

            btnLast7Days_Click(sender, e);
        }

        private void LoadInfo()
        {
            DateTime startDate = dtpStartDate.Value,
                    endDate = dtpEndDate.Value;
            lblNumOrder.Text = busBill.CountNumBills(startDate, endDate).ToString();
            lblTotalSales.Text = Tools.ConvertToCurrency(busBill.GetTotalSale(startDate, endDate));
            dgvTopProducts.DataSource = busBill.TopProducts(startDate, endDate).Select(x => new { x.Ten, TongTien = Tools.ConvertToCurrency((int)x.TongTien) }).ToList();

            chartRevenue.ResetAutoValues();
            chartRevenue.DataSource = busBill.RevenueByDate(startDate, endDate);

            chartBillType.ResetAutoValues();
            chartBillType.DataSource = busBill.RevenueByBillType(startDate, endDate);
        }

        private void setCusomDate(bool status)
        {
            dtpStartDate.Enabled = status;
            dtpEndDate.Enabled = status;
            btnOkCustomDate.Visible = status;
        }
    }
}