using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Account : Form
    {
        private TaiKhoan accountFromForm;
        private BUS_Account busAccount = new BUS_Account();
        private BUS_Position busPosition = new BUS_Position();

        public GUI_Account()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetAccountFromForm();
            if (accountFromForm != null)
            {
                if (accountFromForm.MatKhau.Length >= 6)
                {
                    if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (busAccount.Add(accountFromForm))
                        {
                            MessageBox.Show("Thêm thành công!");
                            UpdateDgv(busAccount.GetAll());
                        }
                        else MessageBox.Show("Tên đăng nhập đã tồn tại");
                    }
                }
                else MessageBox.Show("Mật khẩu tối thiểu 6 ký tự!");
            }
            else MessageBox.Show("Tên tài khoản đã tồn tại!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkTextBox(txtUn))
            {
                if (txtUn.Text != BUS_Account.currentAccount.TenDangNhap)
                {
                    if (MessageBox.Show($"Xác nhận xoá tài khoản '{txtUn.Text}'", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (busAccount.Delete(txtUn.Text))
                        {
                            MessageBox.Show("Xoá thành công!");
                            UpdateDgv(busAccount.GetAll());
                        }
                        else MessageBox.Show("Tên đăng nhập không tồn tại!");
                    }
                }
                else MessageBox.Show("Không thể xoá tài khoản khi đang đăng nhập");
            }
            else MessageBox.Show("Chưa có tài khoản nào được chọn!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetAccountFromForm();
            if (accountFromForm != null)
            {
                if (accountFromForm.MatKhau.Length >= 6)
                {
                    if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (busAccount.Update(accountFromForm))
                        {
                            MessageBox.Show("Sửa thông tin thành công!");
                            UpdateDgv(busAccount.GetAll());
                        }
                        else MessageBox.Show("Tên đăng nhập không tồn tại!");
                    }
                }
                else MessageBox.Show("Mật khẩu tối thiểu 6 ký tự!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtUn.Clear();
            txtPw.Clear();
            txtEmail.Clear();
            cboPosition.SelectedIndex = 0;
            UpdateDgv(busAccount.GetAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(busAccount.SearchAccountByUn(txtSearch.Text));
        }

        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDgv(busAccount.SearchAccountsByPositionID(cboPosition.SelectedValue.ToString()).ToList());
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

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string un = dgvAccount[0, e.RowIndex].Value.ToString();
            TaiKhoan a = busAccount.GetAccountByUn(un);
            txtUn.Text = un;
            txtPw.Text = a.MatKhau;
            txtEmail.Text = a.Email;
            cboPosition.SelectedValue = a.MaQuyen;
        }

        private void GetAccountFromForm()
        {
            if (checkTextBox(txtUn) && checkTextBox(txtPw) && checkTextBox(txtEmail))
            {
                accountFromForm = new TaiKhoan
                {
                    TenDangNhap = txtUn.Text,
                    MatKhau = txtPw.Text,
                    Email = txtEmail.Text,
                    MaQuyen = cboPosition.SelectedValue.ToString()
                };
            }
            else
            {
                accountFromForm = null;
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void GUI_Account_Load(object sender, System.EventArgs e)
        {
            cboPosition.DataSource = busPosition.GetAll();
            cboPosition.ValueMember = "Ma";
            cboPosition.DisplayMember = "Ten";

            UpdateDgv(busAccount.GetAll());
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void txtUn_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void UpdateDgv(List<TaiKhoan> accountList)
        {
            dgvAccount.DataSource = accountList.Select(x => new { x.TenDangNhap, x.MatKhau, x.Email, Quyen = x.Quyen.Ten }).ToList();
        }
    }
}