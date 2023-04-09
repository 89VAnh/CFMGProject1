using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Register : Form
    {
        bool isHidePw = true;
        bool isHideRePw = true;
        BUS_Position busPosition = new BUS_Position();
        BUS_Account busAccount = new BUS_Account();
        public GUI_Register()
        {
            InitializeComponent();
        }

        private void txtPw_IconRightClick(object sender, EventArgs e)
        {
            isHidePw = !isHidePw;
            if (isHidePw)
            {
                txtPw.IconRight = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.Length - 9) + "Resources/show-pw.png");
                txtPw.PasswordChar = '●';
            }
            else
            {
                txtPw.IconRight = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.Length - 9) + "Resources/hide-pw.png");
                txtPw.PasswordChar = '\0';
            }
        }

        private void txtRePw_IconRightClick(object sender, EventArgs e)
        {
            isHideRePw = !isHideRePw;
            if (isHideRePw)
            {
                txtRePw.IconRight = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.Length - 9) + "Resources/show-pw.png");
                txtRePw.PasswordChar = '●';
            }
            else
            {
                txtRePw.IconRight = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.Length - 9) + "Resources/hide-pw.png");
                txtRePw.PasswordChar = '\0';
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            cboPosition.DataSource = busPosition.GetPositions();
            cboPosition.ValueMember = "Ma";
            cboPosition.DisplayMember = "Ten";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GUI_Login f = new GUI_Login();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        private bool checkTextBox(Guna2TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, "Vui lòng nhập trường này");
                return false;
            }
            else return true;
        }
        private TaiKhoan getAccountFromForm()
        {
            if (checkTextBox(txtUn) && checkTextBox(txtPw) && checkTextBox(txtEmail))
            {
                return new TaiKhoan
                {
                    TenDangNhap = txtUn.Text,
                    MatKhau = txtPw.Text,
                    Email = txtEmail.Text,
                    MaQuyen = cboPosition.SelectedValue.ToString()
                };
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return null;
            }
        }
        private bool checkEmail(string email)
        {
            return Regex.Match(email, @"^([\w\.-]+)@([\w-]+)((\.(\w){2,3})+)$").Success;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            TaiKhoan accountFromForm = getAccountFromForm();

            if (!busAccount.CheckUn(accountFromForm.TenDangNhap))
            {
                if (txtPw.Text.Length >= 6)
                {
                    if (txtRePw.Text == txtPw.Text)
                    {
                        if (checkEmail(txtEmail.Text))
                        {
                            busAccount.Add(accountFromForm);
                            MessageBox.Show("Đăng ký thành công!");
                            GUI_Login f = new GUI_Login();
                            this.Hide();
                            f.ShowDialog();
                            this.Close();
                        }
                        else MessageBox.Show("Email không đúng định dạng");
                    }
                    else MessageBox.Show("Nhập lại mật khẩu không trùng khớp");
                }
                else MessageBox.Show("Mật khẩu chứa tối thiểu 6 ký tự");
            }
            else MessageBox.Show("Tên tài khoản đã tồn tại!");

        }
    }
}
