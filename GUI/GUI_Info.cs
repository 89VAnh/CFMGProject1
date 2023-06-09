﻿using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Info : Form
    {
        private TaiKhoan account;
        private BUS_Account busAccount = new BUS_Account();

        public GUI_Info()
        {
            InitializeComponent();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            if (checkTextBox(txtOldPw) && checkTextBox(txtNewPw) && checkTextBox(txtRePw))
            {
                if (txtOldPw.Text == account.MatKhau)
                {
                    if (txtNewPw.Text.Length >= 6)
                    {
                        if (txtRePw.Text == txtNewPw.Text)
                        {
                            account.MatKhau = txtNewPw.Text;
                            busAccount.Update(account);
                            MessageBox.Show("Đổi mật khẩu Thành công!");
                            txtOldPw.Clear();
                            txtNewPw.Clear();
                            txtRePw.Clear();
                        }
                        else MessageBox.Show("Mật khẩu nhập lại không chính xác!");
                    }
                    else errorProvider.SetError(txtNewPw, "Mật khẩu tối thiểu 6 ký tự!");
                }
                else MessageBox.Show("Mật khẩu cũ không chính xác!");
            }
            else MessageBox.Show("Vui lòng điền đầy đủ thông tin");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (account != null)
            {
                if (MessageBox.Show("Xác nhận lưu thông tin", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    account.Email = txtEmail.Text;
                    busAccount.Update(account);
                    MessageBox.Show("Lưu thành công!");
                    GUI_Info_Load(sender, e);
                }
            }
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

        private void GUI_Info_Load(object sender, EventArgs e)
        {
            account = BUS_Account.currentAccount;
            txtUn.Text = account.TenDangNhap;
            txtEmail.Text = account.Email;
        }

        private void txtNewPw_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtOldPw_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtRePw_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}