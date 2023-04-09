namespace GUI
{
    partial class GUI_Main
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoáĐơnTạiQuánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoáĐơnMangVềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoáĐơnGiaoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thựcĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sttWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.quảnLýToolStripMenuItem1});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(843, 44);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "MenuStrip";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Image = global::GUI.Properties.Resources.system;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(116, 40);
            this.hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Image = global::GUI.Properties.Resources.skills;
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "&Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::GUI.Properties.Resources.logout;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng &xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hoáĐơnTạiQuánToolStripMenuItem,
            this.hoáĐơnMangVềToolStripMenuItem,
            this.hoáĐơnGiaoHàngToolStripMenuItem,
            this.kháchHàngToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Image = global::GUI.Properties.Resources.create_bill;
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(141, 40);
            this.quảnLýToolStripMenuItem.Text = "&Tạo hoá đơn";
            // 
            // hoáĐơnTạiQuánToolStripMenuItem
            // 
            this.hoáĐơnTạiQuánToolStripMenuItem.Image = global::GUI.Properties.Resources.shop;
            this.hoáĐơnTạiQuánToolStripMenuItem.Name = "hoáĐơnTạiQuánToolStripMenuItem";
            this.hoáĐơnTạiQuánToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.hoáĐơnTạiQuánToolStripMenuItem.Text = "Hoá đơn tại quán";
            this.hoáĐơnTạiQuánToolStripMenuItem.Click += new System.EventHandler(this.hoáĐơnTạiQuánToolStripMenuItem_Click);
            // 
            // hoáĐơnMangVềToolStripMenuItem
            // 
            this.hoáĐơnMangVềToolStripMenuItem.Image = global::GUI.Properties.Resources.bill;
            this.hoáĐơnMangVềToolStripMenuItem.Name = "hoáĐơnMangVềToolStripMenuItem";
            this.hoáĐơnMangVềToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.hoáĐơnMangVềToolStripMenuItem.Text = "Hoá đơn mang về";
            this.hoáĐơnMangVềToolStripMenuItem.Click += new System.EventHandler(this.hoáĐơnMangVềToolStripMenuItem_Click);
            // 
            // hoáĐơnGiaoHàngToolStripMenuItem
            // 
            this.hoáĐơnGiaoHàngToolStripMenuItem.Image = global::GUI.Properties.Resources.delivery_package_person;
            this.hoáĐơnGiaoHàngToolStripMenuItem.Name = "hoáĐơnGiaoHàngToolStripMenuItem";
            this.hoáĐơnGiaoHàngToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.hoáĐơnGiaoHàngToolStripMenuItem.Text = "Hoá đơn giao hàng";
            this.hoáĐơnGiaoHàngToolStripMenuItem.Click += new System.EventHandler(this.hoáĐơnGiaoHàngToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = global::GUI.Properties.Resources.customer;
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem1
            // 
            this.quảnLýToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.thựcĐơnToolStripMenuItem,
            this.bànToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.toolStripSeparator1,
            this.doanhThuToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.quảnLýToolStripMenuItem1.Image = global::GUI.Properties.Resources.blogger;
            this.quảnLýToolStripMenuItem1.Name = "quảnLýToolStripMenuItem1";
            this.quảnLýToolStripMenuItem1.Size = new System.Drawing.Size(103, 40);
            this.quảnLýToolStripMenuItem1.Text = "&Quản lý";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.Image = global::GUI.Properties.Resources.information;
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.danhMụcToolStripMenuItem.Text = "&Danh mục";
            this.danhMụcToolStripMenuItem.Click += new System.EventHandler(this.danhMụcToolStripMenuItem_Click);
            // 
            // thựcĐơnToolStripMenuItem
            // 
            this.thựcĐơnToolStripMenuItem.Image = global::GUI.Properties.Resources.menu;
            this.thựcĐơnToolStripMenuItem.Name = "thựcĐơnToolStripMenuItem";
            this.thựcĐơnToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.thựcĐơnToolStripMenuItem.Text = "Thự&c đơn";
            this.thựcĐơnToolStripMenuItem.Click += new System.EventHandler(this.thựcĐơnToolStripMenuItem_Click);
            // 
            // bànToolStripMenuItem
            // 
            this.bànToolStripMenuItem.Image = global::GUI.Properties.Resources.chair;
            this.bànToolStripMenuItem.Name = "bànToolStripMenuItem";
            this.bànToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.bànToolStripMenuItem.Text = "&Bàn";
            this.bànToolStripMenuItem.Click += new System.EventHandler(this.bànToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Image = global::GUI.Properties.Resources.staff;
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Image = global::GUI.Properties.Resources.skills;
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.tàiKhoảnToolStripMenuItem.Text = "&Tài khoản";
            this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Image = global::GUI.Properties.Resources.salary;
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.doanhThuToolStripMenuItem.Text = "Doan&h thu";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Image = global::GUI.Properties.Resources.analytics;
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.thốngKêToolStripMenuItem.Text = "Thống &kê";
            // 
            // sttWelcome
            // 
            this.sttWelcome.Name = "sttWelcome";
            this.sttWelcome.Size = new System.Drawing.Size(49, 20);
            this.sttWelcome.Text = "Status";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttWelcome});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusStrip";
            // 
            // GUI_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 558);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GUI_Main";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thựcĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel sttWelcome;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem hoáĐơnTạiQuánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoáĐơnMangVềToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoáĐơnGiaoHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
    }
}
