using BUS;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class GUI_Statistic : Form
    {
        BUS_Bill busBill = new BUS_Bill();

        public GUI_Statistic()
        {
            InitializeComponent();
        }

        private void UpdateChart()
        {
            // Create series for each Y-value member
            var seriesTaiQuan = new Series("Doanh thu tại quán");
            var seriesMangVe = new Series("Doanh thu mang về");
            var seriesGiaoHang = new Series("Doanh thu giao hàng");

            // Set X-value member for all series
            seriesTaiQuan.XValueMember = "ThoiGian";
            seriesMangVe.XValueMember = "ThoiGian";
            seriesGiaoHang.XValueMember = "ThoiGian";

            // Set Y-value member for each series
            seriesTaiQuan.YValueMembers = "DoanhThuTaiQuan";
            seriesMangVe.YValueMembers = "DoanhThuMangVe";
            seriesGiaoHang.YValueMembers = "DoanhThuGiaoHang";

            // Add series to chart
            chartRevenueByDate.Series.Clear();
            chartRevenueByDate.Series.Add(seriesTaiQuan);
            chartRevenueByDate.Series.Add(seriesMangVe);
            chartRevenueByDate.Series.Add(seriesGiaoHang);

        }

        private void GUI_Statistic_Load(object sender, EventArgs e)
        {
            chartRevenueByDate.DataSource = busBill.GetRevenueByDate();
            chartRevenueByMonth.DataSource = busBill.GetRevenueByMonth();
            chartRevenueByYear.DataSource = busBill.GetRevenueByYear();
            chartRevenueByDate.Visible = true;
            chartRevenueByMonth.Visible = false;
            chartRevenueByYear.Visible = false;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.SelectedIndex)
            {
                case 0:
                    chartRevenueByDate.Visible = true;
                    chartRevenueByMonth.Visible = false;
                    chartRevenueByYear.Visible = false;
                    break;
                case 1:
                    chartRevenueByDate.Visible = false;
                    chartRevenueByMonth.Visible = true;
                    chartRevenueByYear.Visible = false;
                    break;
                case 2:
                    chartRevenueByDate.Visible = false;
                    chartRevenueByMonth.Visible = false;
                    chartRevenueByYear.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}
