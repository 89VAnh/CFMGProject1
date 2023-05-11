namespace GUI
{
    partial class GUI_Statistic2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartRevenueByDate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.cboType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chartRevenueByMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRevenueByYear = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByYear)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRevenueByDate
            // 
            this.chartRevenueByDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRevenueByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByDate.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByDate.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByDate.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartRevenueByDate.BorderlineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chartRevenueByDate.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartRevenueByDate.Legends.Add(legend1);
            this.chartRevenueByDate.Location = new System.Drawing.Point(12, 217);
            this.chartRevenueByDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartRevenueByDate.Name = "chartRevenueByDate";
            this.chartRevenueByDate.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Doanh thu HD tại quán";
            series1.XValueMember = "ThoiGian";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "DoanhThuTaiQuan";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Doanh thu HD mang về";
            series2.XValueMember = "ThoiGian";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "DoanhThuMangVe";
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Doanh Thu HD Giao Hàng";
            series3.XValueMember = "ThoiGian";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueMembers = "DoanhThuGiaoHang";
            this.chartRevenueByDate.Series.Add(series1);
            this.chartRevenueByDate.Series.Add(series2);
            this.chartRevenueByDate.Series.Add(series3);
            this.chartRevenueByDate.Size = new System.Drawing.Size(1155, 434);
            this.chartRevenueByDate.TabIndex = 1;
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Doanh thu theo ngày";
            this.chartRevenueByDate.Titles.Add(title1);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(101, 27);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(378, 47);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "THỐNG KÊ DOANH THU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.label8.Location = new System.Drawing.Point(81, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 23);
            this.label8.TabIndex = 85;
            this.label8.Text = "Xem thống kê theo :";
            // 
            // cboType
            // 
            this.cboType.AutoRoundedCorners = true;
            this.cboType.BackColor = System.Drawing.Color.Transparent;
            this.cboType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.cboType.BorderRadius = 17;
            this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboType.ItemHeight = 30;
            this.cboType.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.cboType.Location = new System.Drawing.Point(271, 129);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(208, 36);
            this.cboType.StartIndex = 0;
            this.cboType.TabIndex = 86;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // chartRevenueByMonth
            // 
            this.chartRevenueByMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRevenueByMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByMonth.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByMonth.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByMonth.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartRevenueByMonth.BorderlineWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chartRevenueByMonth.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartRevenueByMonth.Legends.Add(legend2);
            this.chartRevenueByMonth.Location = new System.Drawing.Point(12, 227);
            this.chartRevenueByMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartRevenueByMonth.Name = "chartRevenueByMonth";
            this.chartRevenueByMonth.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series4.ChartArea = "ChartArea1";
            series4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Doanh thu HD tại quán";
            series4.XValueMember = "ThoiGian";
            series4.YValueMembers = "DoanhThuTaiQuan";
            series5.ChartArea = "ChartArea1";
            series5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.IsValueShownAsLabel = true;
            series5.Legend = "Legend1";
            series5.Name = "Doanh thu HD mang về";
            series5.XValueMember = "ThoiGian";
            series5.YValueMembers = "DoanhThuMangVe";
            series6.ChartArea = "ChartArea1";
            series6.IsValueShownAsLabel = true;
            series6.Legend = "Legend1";
            series6.Name = "Doanh Thu HD Giao Hàng";
            series6.XValueMember = "ThoiGian";
            series6.YValueMembers = "DoanhThuGiaoHang";
            this.chartRevenueByMonth.Series.Add(series4);
            this.chartRevenueByMonth.Series.Add(series5);
            this.chartRevenueByMonth.Series.Add(series6);
            this.chartRevenueByMonth.Size = new System.Drawing.Size(1155, 424);
            this.chartRevenueByMonth.TabIndex = 87;
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Doanh thu theo tháng";
            this.chartRevenueByMonth.Titles.Add(title2);
            // 
            // chartRevenueByYear
            // 
            this.chartRevenueByYear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRevenueByYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByYear.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByYear.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.chartRevenueByYear.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartRevenueByYear.BorderlineWidth = 0;
            chartArea3.Name = "ChartArea1";
            this.chartRevenueByYear.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartRevenueByYear.Legends.Add(legend3);
            this.chartRevenueByYear.Location = new System.Drawing.Point(12, 227);
            this.chartRevenueByYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartRevenueByYear.Name = "chartRevenueByYear";
            this.chartRevenueByYear.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series7.ChartArea = "ChartArea1";
            series7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.IsValueShownAsLabel = true;
            series7.Legend = "Legend1";
            series7.Name = "Doanh thu HD tại quán";
            series7.XValueMember = "ThoiGian";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series7.YValueMembers = "DoanhThuTaiQuan";
            series8.ChartArea = "ChartArea1";
            series8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series8.IsValueShownAsLabel = true;
            series8.Legend = "Legend1";
            series8.Name = "Doanh thu HD mang về";
            series8.XValueMember = "ThoiGian";
            series8.YValueMembers = "DoanhThuMangVe";
            series9.ChartArea = "ChartArea1";
            series9.IsValueShownAsLabel = true;
            series9.Legend = "Legend1";
            series9.Name = "Doanh Thu HD Giao Hàng";
            series9.XValueMember = "ThoiGian";
            series9.YValueMembers = "DoanhThuGiaoHang";
            this.chartRevenueByYear.Series.Add(series7);
            this.chartRevenueByYear.Series.Add(series8);
            this.chartRevenueByYear.Series.Add(series9);
            this.chartRevenueByYear.Size = new System.Drawing.Size(1155, 424);
            this.chartRevenueByYear.TabIndex = 88;
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Doanh thu theo năm";
            this.chartRevenueByYear.Titles.Add(title3);
            // 
            // GUI_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1179, 654);
            this.Controls.Add(this.chartRevenueByYear);
            this.Controls.Add(this.chartRevenueByMonth);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.chartRevenueByDate);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GUI_Statistic";
            this.Text = "GUI_Statistic";
            this.Load += new System.EventHandler(this.GUI_Statistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueByDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox cboType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueByMonth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueByYear;
    }
}