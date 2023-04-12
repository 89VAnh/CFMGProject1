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
            this.components = new System.ComponentModel.Container();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPosition = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnBill = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBill = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnBillDelivery = new Guna.UI2.WinForms.Guna2Button();
            this.btnBillAtShop = new Guna.UI2.WinForms.Guna2Button();
            this.btnBillTakeAway = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnInfo = new Guna.UI2.WinForms.Guna2Button();
            this.pnlManage = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_ThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btn_DoanhThu = new Guna.UI2.WinForms.Guna2Button();
            this.btnAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaff = new Guna.UI2.WinForms.Guna2Button();
            this.btnTable = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategory = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.btnManage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.pnlBill.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.pnlManage.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = false;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.lbTime.Location = new System.Drawing.Point(795, 16);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(140, 29);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "HH:MM:SS";
            this.lbTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = false;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.lblName.Location = new System.Drawing.Point(192, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(248, 34);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nguyễn Việt Anh";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = false;
            this.lblPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.lblPosition.Location = new System.Drawing.Point(566, 16);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(170, 30);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "Admin";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.AutoSize = false;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(452, 16);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(170, 30);
            this.guna2HtmlLabel4.TabIndex = 0;
            this.guna2HtmlLabel4.Text = "Chức vụ:";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Controls.Add(this.lbTime);
            this.guna2Panel2.Controls.Add(this.lblName);
            this.guna2Panel2.Controls.Add(this.lblPosition);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel6);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel4);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(297, 48);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(985, 58);
            this.guna2Panel2.TabIndex = 7;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(78, 16);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(170, 30);
            this.guna2HtmlLabel6.TabIndex = 0;
            this.guna2HtmlLabel6.Text = "Xin chào:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(48, 11);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(553, 34);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = "Hoà mình vào không gian A - Coffee";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.guna2Panel4.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel4.Location = new System.Drawing.Point(297, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(985, 48);
            this.guna2Panel4.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Animated = true;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnLogout.Image = global::GUI.Properties.Resources.logout;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.ImageSize = new System.Drawing.Size(33, 33);
            this.btnLogout.Location = new System.Drawing.Point(0, 913);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(297, 45);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBill
            // 
            this.btnBill.Animated = true;
            this.btnBill.BackColor = System.Drawing.Color.Transparent;
            this.btnBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBill.FillColor = System.Drawing.Color.Transparent;
            this.btnBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnBill.Image = global::GUI.Properties.Resources.create_bill;
            this.btnBill.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBill.ImageSize = new System.Drawing.Size(33, 33);
            this.btnBill.Location = new System.Drawing.Point(0, 140);
            this.btnBill.Name = "btnBill";
            this.btnBill.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBill.Size = new System.Drawing.Size(297, 60);
            this.btnBill.TabIndex = 2;
            this.btnBill.Text = "Tạo hoá đơn";
            this.btnBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBill.UseTransparentBackground = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // pnlBill
            // 
            this.pnlBill.BackColor = System.Drawing.Color.Transparent;
            this.pnlBill.Controls.Add(this.btnCustomer);
            this.pnlBill.Controls.Add(this.btnBillDelivery);
            this.pnlBill.Controls.Add(this.btnBillAtShop);
            this.pnlBill.Controls.Add(this.btnBillTakeAway);
            this.pnlBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBill.Location = new System.Drawing.Point(0, 200);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(297, 219);
            this.pnlBill.TabIndex = 3;
            this.pnlBill.Visible = false;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Animated = true;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.Transparent;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnCustomer.Image = global::GUI.Properties.Resources.customer;
            this.btnCustomer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.ImageSize = new System.Drawing.Size(22, 22);
            this.btnCustomer.Location = new System.Drawing.Point(21, 165);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnCustomer.Size = new System.Drawing.Size(308, 45);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Khách hàng";
            this.btnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnBillDelivery
            // 
            this.btnBillDelivery.Animated = true;
            this.btnBillDelivery.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBillDelivery.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBillDelivery.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBillDelivery.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBillDelivery.FillColor = System.Drawing.Color.Transparent;
            this.btnBillDelivery.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnBillDelivery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnBillDelivery.Image = global::GUI.Properties.Resources.delivery_package_person;
            this.btnBillDelivery.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBillDelivery.ImageSize = new System.Drawing.Size(22, 22);
            this.btnBillDelivery.Location = new System.Drawing.Point(21, 114);
            this.btnBillDelivery.Name = "btnBillDelivery";
            this.btnBillDelivery.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBillDelivery.Size = new System.Drawing.Size(308, 45);
            this.btnBillDelivery.TabIndex = 0;
            this.btnBillDelivery.Text = "Hoá đơn giao hàng";
            this.btnBillDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBillDelivery.Click += new System.EventHandler(this.btnBillDelivery_Click);
            // 
            // btnBillAtShop
            // 
            this.btnBillAtShop.Animated = true;
            this.btnBillAtShop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBillAtShop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBillAtShop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBillAtShop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBillAtShop.FillColor = System.Drawing.Color.Transparent;
            this.btnBillAtShop.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnBillAtShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnBillAtShop.Image = global::GUI.Properties.Resources.shop;
            this.btnBillAtShop.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBillAtShop.ImageSize = new System.Drawing.Size(22, 22);
            this.btnBillAtShop.Location = new System.Drawing.Point(21, 6);
            this.btnBillAtShop.Name = "btnBillAtShop";
            this.btnBillAtShop.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBillAtShop.Size = new System.Drawing.Size(330, 51);
            this.btnBillAtShop.TabIndex = 0;
            this.btnBillAtShop.Text = "Hoá đơn tại quán";
            this.btnBillAtShop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBillAtShop.Click += new System.EventHandler(this.btnBillAtShop_Click);
            // 
            // btnBillTakeAway
            // 
            this.btnBillTakeAway.Animated = true;
            this.btnBillTakeAway.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBillTakeAway.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBillTakeAway.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBillTakeAway.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBillTakeAway.FillColor = System.Drawing.Color.Transparent;
            this.btnBillTakeAway.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnBillTakeAway.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnBillTakeAway.Image = global::GUI.Properties.Resources.bill;
            this.btnBillTakeAway.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBillTakeAway.ImageSize = new System.Drawing.Size(22, 22);
            this.btnBillTakeAway.Location = new System.Drawing.Point(21, 63);
            this.btnBillTakeAway.Name = "btnBillTakeAway";
            this.btnBillTakeAway.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBillTakeAway.Size = new System.Drawing.Size(308, 45);
            this.btnBillTakeAway.TabIndex = 0;
            this.btnBillTakeAway.Text = "Hoá đơn mang về";
            this.btnBillTakeAway.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBillTakeAway.Click += new System.EventHandler(this.btnBillTakeAway_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.btnLogout);
            this.guna2Panel1.Controls.Add(this.btnInfo);
            this.guna2Panel1.Controls.Add(this.pnlManage);
            this.guna2Panel1.Controls.Add(this.btnManage);
            this.guna2Panel1.Controls.Add(this.pnlBill);
            this.guna2Panel1.Controls.Add(this.btnBill);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(297, 958);
            this.guna2Panel1.TabIndex = 6;
            // 
            // btnInfo
            // 
            this.btnInfo.Animated = true;
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfo.FillColor = System.Drawing.Color.Transparent;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnInfo.Image = global::GUI.Properties.Resources.system;
            this.btnInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInfo.ImageSize = new System.Drawing.Size(33, 33);
            this.btnInfo.Location = new System.Drawing.Point(0, 851);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInfo.Size = new System.Drawing.Size(297, 45);
            this.btnInfo.TabIndex = 15;
            this.btnInfo.Text = "Thông tin tài khoản";
            this.btnInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // pnlManage
            // 
            this.pnlManage.BackColor = System.Drawing.Color.Transparent;
            this.pnlManage.Controls.Add(this.btn_ThongKe);
            this.pnlManage.Controls.Add(this.btn_DoanhThu);
            this.pnlManage.Controls.Add(this.btnAccount);
            this.pnlManage.Controls.Add(this.btnStaff);
            this.pnlManage.Controls.Add(this.btnTable);
            this.pnlManage.Controls.Add(this.btnCategory);
            this.pnlManage.Controls.Add(this.btnMenu);
            this.pnlManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlManage.Location = new System.Drawing.Point(0, 479);
            this.pnlManage.Name = "pnlManage";
            this.pnlManage.Size = new System.Drawing.Size(297, 372);
            this.pnlManage.TabIndex = 5;
            this.pnlManage.Visible = false;
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.Animated = true;
            this.btn_ThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btn_ThongKe.Image = global::GUI.Properties.Resources.analytics;
            this.btn_ThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThongKe.ImageSize = new System.Drawing.Size(22, 22);
            this.btn_ThongKe.Location = new System.Drawing.Point(21, 318);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_ThongKe.Size = new System.Drawing.Size(308, 45);
            this.btn_ThongKe.TabIndex = 0;
            this.btn_ThongKe.Text = "Thống kê";
            this.btn_ThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.Animated = true;
            this.btn_DoanhThu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DoanhThu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DoanhThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DoanhThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DoanhThu.FillColor = System.Drawing.Color.Transparent;
            this.btn_DoanhThu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btn_DoanhThu.Image = global::GUI.Properties.Resources.salary;
            this.btn_DoanhThu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_DoanhThu.ImageSize = new System.Drawing.Size(22, 22);
            this.btn_DoanhThu.Location = new System.Drawing.Point(21, 267);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Padding = new System.Windows.Forms.Padding(36, 0, 0, 0);
            this.btn_DoanhThu.Size = new System.Drawing.Size(306, 45);
            this.btn_DoanhThu.TabIndex = 0;
            this.btn_DoanhThu.Text = "Doanh thu";
            this.btn_DoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAccount
            // 
            this.btnAccount.Animated = true;
            this.btnAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAccount.FillColor = System.Drawing.Color.Transparent;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnAccount.Image = global::GUI.Properties.Resources.skills;
            this.btnAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccount.ImageSize = new System.Drawing.Size(22, 22);
            this.btnAccount.Location = new System.Drawing.Point(21, 216);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAccount.Size = new System.Drawing.Size(308, 45);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Tài khoản";
            this.btnAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Animated = true;
            this.btnStaff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStaff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStaff.FillColor = System.Drawing.Color.Transparent;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnStaff.Image = global::GUI.Properties.Resources.staff;
            this.btnStaff.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStaff.ImageSize = new System.Drawing.Size(22, 22);
            this.btnStaff.Location = new System.Drawing.Point(21, 165);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStaff.Size = new System.Drawing.Size(308, 45);
            this.btnStaff.TabIndex = 0;
            this.btnStaff.Text = "Nhân viên";
            this.btnStaff.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnTable
            // 
            this.btnTable.Animated = true;
            this.btnTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTable.FillColor = System.Drawing.Color.Transparent;
            this.btnTable.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnTable.Image = global::GUI.Properties.Resources.chair;
            this.btnTable.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTable.ImageSize = new System.Drawing.Size(22, 22);
            this.btnTable.Location = new System.Drawing.Point(21, 114);
            this.btnTable.Name = "btnTable";
            this.btnTable.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTable.Size = new System.Drawing.Size(308, 45);
            this.btnTable.TabIndex = 0;
            this.btnTable.Text = "Bàn";
            this.btnTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Animated = true;
            this.btnCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCategory.FillColor = System.Drawing.Color.Transparent;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnCategory.Image = global::GUI.Properties.Resources.information;
            this.btnCategory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategory.ImageSize = new System.Drawing.Size(22, 22);
            this.btnCategory.Location = new System.Drawing.Point(21, 6);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(308, 45);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Danh mục";
            this.btnCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Animated = true;
            this.btnMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenu.FillColor = System.Drawing.Color.Transparent;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnMenu.Image = global::GUI.Properties.Resources.menu;
            this.btnMenu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenu.ImageSize = new System.Drawing.Size(22, 22);
            this.btnMenu.Location = new System.Drawing.Point(21, 63);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnMenu.Size = new System.Drawing.Size(308, 45);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "Thực đơn";
            this.btnMenu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnManage
            // 
            this.btnManage.Animated = true;
            this.btnManage.BackColor = System.Drawing.Color.Transparent;
            this.btnManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManage.FillColor = System.Drawing.Color.Transparent;
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.btnManage.Image = global::GUI.Properties.Resources.blogger;
            this.btnManage.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManage.ImageSize = new System.Drawing.Size(33, 33);
            this.btnManage.Location = new System.Drawing.Point(0, 419);
            this.btnManage.Name = "btnManage";
            this.btnManage.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManage.Size = new System.Drawing.Size(297, 60);
            this.btnManage.TabIndex = 4;
            this.btnManage.Text = "Quản lý";
            this.btnManage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(297, 140);
            this.guna2Panel3.TabIndex = 0;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::GUI.Properties.Resources.coffee1;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(86, 11);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(73, 62);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 5;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(55, 79);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(267, 50);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "A - Coffee";
            // 
            // GUI_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 958);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GUI_Main";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_Main_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.pnlBill.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.pnlManage.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Timer timerTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPosition;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnBill;
        private Guna.UI2.WinForms.Guna2Panel pnlBill;
        private Guna.UI2.WinForms.Guna2Button btnCustomer;
        private Guna.UI2.WinForms.Guna2Button btnBillDelivery;
        private Guna.UI2.WinForms.Guna2Button btnBillAtShop;
        private Guna.UI2.WinForms.Guna2Button btnBillTakeAway;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlManage;
        private Guna.UI2.WinForms.Guna2Button btnStaff;
        private Guna.UI2.WinForms.Guna2Button btnTable;
        private Guna.UI2.WinForms.Guna2Button btnCategory;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private Guna.UI2.WinForms.Guna2Button btnManage;
        private Guna.UI2.WinForms.Guna2Button btn_DoanhThu;
        private Guna.UI2.WinForms.Guna2Button btnAccount;
        private Guna.UI2.WinForms.Guna2Button btnInfo;
        private Guna.UI2.WinForms.Guna2Button btn_ThongKe;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
    }
}
