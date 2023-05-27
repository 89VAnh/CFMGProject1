using BUS;
using System;
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
            if (string.IsNullOrWhiteSpace(un)) { errorProvider.SetError(txtUn, "Vui lòng nhập trường này"); txtUn.Focus(); return; }
            if (string.IsNullOrWhiteSpace(pw)) { errorProvider.SetError(txtPw, "Vui lòng nhập trường này"); txtPw.Focus(); return; }

            if (un.Length > 100) { errorProvider.SetError(txtUn, "Tên đăng nhập không vượt quá 100 ký tự!"); txtUn.Focus(); return; }
            if (pw.Length > 100) { errorProvider.SetError(txtPw, "Mật khẩu không vượt quá 100 ký tự!"); txtPw.Focus(); return; }

            if (pw.Length < 6) { errorProvider.SetError(txtPw, "Mật khẩu tối thiểu 6 ký tự!"); txtPw.Focus(); return; }

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

        private void txtPw_IconRightClick(object sender, EventArgs e)
        {
            isHidePw = !isHidePw;
            if (isHidePw)
            {
                txtPw.IconRight = global::GUI.Properties.Resources.show_pw;

                txtPw.PasswordChar = '●';
            }
            else
            {
                txtPw.IconRight = global::GUI.Properties.Resources.hide_pw;
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