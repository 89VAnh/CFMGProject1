namespace GUI
{
    partial class GUI_Info
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
            this.txtRePw = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNewPw = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOldPw = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUn = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePw = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRePw
            // 
            this.txtRePw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRePw.AutoRoundedCorners = true;
            this.txtRePw.BorderRadius = 19;
            this.txtRePw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRePw.DefaultText = "";
            this.txtRePw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRePw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRePw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRePw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRePw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRePw.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtRePw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRePw.Location = new System.Drawing.Point(719, 372);
            this.txtRePw.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRePw.Name = "txtRePw";
            this.txtRePw.PasswordChar = '●';
            this.txtRePw.PlaceholderText = "";
            this.txtRePw.SelectedText = "";
            this.txtRePw.Size = new System.Drawing.Size(257, 40);
            this.txtRePw.TabIndex = 5;
            this.txtRePw.UseSystemPasswordChar = true;
            this.txtRePw.TextChanged += new System.EventHandler(this.txtRePw_TextChanged);
            // 
            // txtNewPw
            // 
            this.txtNewPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNewPw.AutoRoundedCorners = true;
            this.txtNewPw.BorderRadius = 19;
            this.txtNewPw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPw.DefaultText = "";
            this.txtNewPw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPw.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtNewPw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPw.Location = new System.Drawing.Point(719, 284);
            this.txtNewPw.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.PasswordChar = '●';
            this.txtNewPw.PlaceholderText = "";
            this.txtNewPw.SelectedText = "";
            this.txtNewPw.Size = new System.Drawing.Size(257, 40);
            this.txtNewPw.TabIndex = 4;
            this.txtNewPw.UseSystemPasswordChar = true;
            this.txtNewPw.TextChanged += new System.EventHandler(this.txtNewPw_TextChanged);
            // 
            // txtOldPw
            // 
            this.txtOldPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOldPw.AutoRoundedCorners = true;
            this.txtOldPw.BorderRadius = 19;
            this.txtOldPw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPw.DefaultText = "";
            this.txtOldPw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOldPw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOldPw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOldPw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOldPw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOldPw.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtOldPw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOldPw.Location = new System.Drawing.Point(719, 209);
            this.txtOldPw.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtOldPw.Name = "txtOldPw";
            this.txtOldPw.PasswordChar = '●';
            this.txtOldPw.PlaceholderText = "";
            this.txtOldPw.SelectedText = "";
            this.txtOldPw.Size = new System.Drawing.Size(257, 40);
            this.txtOldPw.TabIndex = 3;
            this.txtOldPw.UseSystemPasswordChar = true;
            this.txtOldPw.TextChanged += new System.EventHandler(this.txtOldPw_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.AutoRoundedCorners = true;
            this.txtEmail.BorderRadius = 19;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(218, 284);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(257, 40);
            this.txtEmail.TabIndex = 2;
            // 
            // txtUn
            // 
            this.txtUn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUn.AutoRoundedCorners = true;
            this.txtUn.BorderRadius = 19;
            this.txtUn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUn.DefaultText = "";
            this.txtUn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUn.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtUn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUn.Location = new System.Drawing.Point(218, 209);
            this.txtUn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUn.Name = "txtUn";
            this.txtUn.PasswordChar = '\0';
            this.txtUn.PlaceholderText = "";
            this.txtUn.ReadOnly = true;
            this.txtUn.SelectedText = "";
            this.txtUn.Size = new System.Drawing.Size(257, 40);
            this.txtUn.TabIndex = 1;
            this.txtUn.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel10.AutoSize = false;
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(37, 56);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(602, 103);
            this.guna2HtmlLabel10.TabIndex = 0;
            this.guna2HtmlLabel10.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BorderRadius = 21;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(199)))), ((int)(((byte)(184)))));
            this.btnSave.Location = new System.Drawing.Point(295, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChangePw
            // 
            this.btnChangePw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangePw.AutoRoundedCorners = true;
            this.btnChangePw.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.btnChangePw.BorderRadius = 21;
            this.btnChangePw.BorderThickness = 2;
            this.btnChangePw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePw.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePw.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangePw.FillColor = System.Drawing.Color.Transparent;
            this.btnChangePw.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnChangePw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(81)))), ((int)(((byte)(57)))));
            this.btnChangePw.Location = new System.Drawing.Point(526, 455);
            this.btnChangePw.Name = "btnChangePw";
            this.btnChangePw.Size = new System.Drawing.Size(180, 45);
            this.btnChangePw.TabIndex = 6;
            this.btnChangePw.Text = "Đổi mật khẩu";
            this.btnChangePw.Click += new System.EventHandler(this.btnChangePw_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.label8.Location = new System.Drawing.Point(59, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 23);
            this.label8.TabIndex = 83;
            this.label8.Text = "Tên tài khoản :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.label1.Location = new System.Drawing.Point(120, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 84;
            this.label1.Text = "Email :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.label2.Location = new System.Drawing.Point(568, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 85;
            this.label2.Text = "Mật khẩu cũ :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.label3.Location = new System.Drawing.Point(557, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 23);
            this.label3.TabIndex = 86;
            this.label3.Text = "Mật khẩu mới :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(32)))), ((int)(((byte)(13)))));
            this.label4.Location = new System.Drawing.Point(522, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 23);
            this.label4.TabIndex = 87;
            this.label4.Text = "Nhập lại mật khẩu :";
            // 
            // GUI_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 653);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnChangePw);
            this.Controls.Add(this.txtRePw);
            this.Controls.Add(this.txtNewPw);
            this.Controls.Add(this.txtOldPw);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUn);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.btnSave);
            this.Name = "GUI_Info";
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.GUI_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtRePw;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPw;
        private Guna.UI2.WinForms.Guna2TextBox txtOldPw;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtUn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnChangePw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
    }
}
