using BUS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Login : Form
    {
        private BUS_Account busAccount = new BUS_Account();

        private bool isHidePw = true;

        public GUI_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string un = txtUn.Text, pw = txtPw.Text;
            if (string.IsNullOrWhiteSpace(un) || string.IsNullOrWhiteSpace(pw))
            {
                if (string.IsNullOrWhiteSpace(un)) errorProvider.SetError(txtUn, "Vui lòng nhập trường này");
                if (string.IsNullOrWhiteSpace(pw)) errorProvider.SetError(txtPw, "Vui lòng nhập trường này");
            }
            else
            {
                if (busAccount.GetAccount(un, pw) != null)
                {
                    BUS_Account.currentAccount = busAccount.GetAccount(un, pw);
                    GUI_Main mdi = new GUI_Main();
                    this.Hide();
                    mdi.ShowDialog();
                    this.Close();
                }
                else
                {
                    if (busAccount.GetAccountByUn(un) != null)
                    {
                        MessageBox.Show("Mật khẩu không chính xác!");
                        txtPw.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản không chính xác!");
                        txtUn.Focus();
                    }
                }
            }
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

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtUn_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}