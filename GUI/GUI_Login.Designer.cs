namespace GUI
{
    partial class GUI_Login
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtUn = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPw = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Chocolate;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(581, 223);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(225, 67);
            this.guna2HtmlLabel2.TabIndex = 16;
            this.guna2HtmlLabel2.Text = "ĐĂNG NHẬP";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Lucida Calligraphy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Chocolate;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(517, 74);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(281, 56);
            this.guna2HtmlLabel1.TabIndex = 13;
            this.guna2HtmlLabel1.Text = "ANH COFFEE";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.AutoRoundedCorners = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderRadius = 21;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(140)))), ((int)(((byte)(99)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnLogin.Location = new System.Drawing.Point(581, 458);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 45);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseTransparentBackground = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.AutoRoundedCorners = true;
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BorderRadius = 20;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegister.FillColor = System.Drawing.Color.Transparent;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnRegister.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnRegister.Image = global::GUI.Properties.Resources.arrow;
            this.btnRegister.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnRegister.Location = new System.Drawing.Point(581, 519);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(180, 42);
            this.btnRegister.TabIndex = 17;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseTransparentBackground = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::GUI.Properties.Resources.cup_of_coffee;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(804, 59);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(82, 86);
            this.guna2PictureBox2.TabIndex = 15;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.UseTransparentBackground = true;
            // 
            // txtUn
            // 
            this.txtUn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUn.BorderColor = System.Drawing.Color.IndianRed;
            this.txtUn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.txtUn.BorderThickness = 2;
            this.txtUn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUn.DefaultText = "";
            this.txtUn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(234)))), ((int)(((byte)(177)))));
            this.txtUn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUn.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtUn.ForeColor = System.Drawing.Color.Brown;
            this.txtUn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUn.IconLeft = global::GUI.Properties.Resources.un;
            this.txtUn.IconLeftOffset = new System.Drawing.Point(-8, 0);
            this.txtUn.IconLeftSize = new System.Drawing.Size(24, 24);
            this.txtUn.Location = new System.Drawing.Point(547, 298);
            this.txtUn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUn.Name = "txtUn";
            this.txtUn.PasswordChar = '\0';
            this.txtUn.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtUn.PlaceholderText = "Tên đăng nhập";
            this.txtUn.SelectedText = "";
            this.txtUn.Size = new System.Drawing.Size(259, 36);
            this.txtUn.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtUn.TabIndex = 10;
            this.txtUn.TextChanged += new System.EventHandler(this.txtUn_TextChanged);
            // 
            // txtPw
            // 
            this.txtPw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPw.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPw.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPw.BorderColor = System.Drawing.Color.IndianRed;
            this.txtPw.BorderThickness = 2;
            this.txtPw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPw.DefaultText = "";
            this.txtPw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPw.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(234)))), ((int)(((byte)(177)))));
            this.txtPw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPw.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtPw.ForeColor = System.Drawing.Color.Brown;
            this.txtPw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPw.IconLeft = global::GUI.Properties.Resources.pw;
            this.txtPw.IconLeftOffset = new System.Drawing.Point(-8, 0);
            this.txtPw.IconLeftSize = new System.Drawing.Size(24, 24);
            this.txtPw.IconRight = global::GUI.Properties.Resources.show_pw;
            this.txtPw.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtPw.IconRightSize = new System.Drawing.Size(16, 16);
            this.txtPw.Location = new System.Drawing.Point(547, 369);
            this.txtPw.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPw.Name = "txtPw";
            this.txtPw.Padding = new System.Windows.Forms.Padding(2);
            this.txtPw.PasswordChar = '●';
            this.txtPw.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPw.PlaceholderText = "Mật khẩu";
            this.txtPw.SelectedText = "";
            this.txtPw.Size = new System.Drawing.Size(259, 36);
            this.txtPw.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPw.TabIndex = 11;
            this.txtPw.IconRightClick += new System.EventHandler(this.txtPw_IconRightClick);
            this.txtPw.TextChanged += new System.EventHandler(this.txtPw_TextChanged);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.Login_Background;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(478, 641);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 14;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.SaddleBrown;
            this.guna2ControlBox3.Location = new System.Drawing.Point(807, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(48, 38);
            this.guna2ControlBox3.TabIndex = 21;
            // 
            // guna2ControlBox4
            // 
            this.guna2ControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox4.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox4.IconColor = System.Drawing.Color.SaddleBrown;
            this.guna2ControlBox4.Location = new System.Drawing.Point(855, 0);
            this.guna2ControlBox4.Name = "guna2ControlBox4";
            this.guna2ControlBox4.Size = new System.Drawing.Size(46, 38);
            this.guna2ControlBox4.TabIndex = 20;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.SaddleBrown;
            this.guna2ControlBox1.Location = new System.Drawing.Point(950, -30);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 38);
            this.guna2ControlBox1.TabIndex = 18;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.SaddleBrown;
            this.guna2ControlBox2.Location = new System.Drawing.Point(902, -30);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(48, 38);
            this.guna2ControlBox2.TabIndex = 19;
            // 
            // GUI_Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(234)))), ((int)(((byte)(177)))));
            this.ClientSize = new System.Drawing.Size(898, 642);
            this.Controls.Add(this.guna2ControlBox3);
            this.Controls.Add(this.guna2ControlBox4);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUn);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtUn;
        private Guna.UI2.WinForms.Guna2TextBox txtPw;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}
