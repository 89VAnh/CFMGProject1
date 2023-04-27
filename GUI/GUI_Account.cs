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
        private BUS_Account busAccount = new BUS_Account();
        private BUS_Position busPosition = new BUS_Position();

        private List<TaiKhoan> accountList = new List<TaiKhoan>();
        private List<Quyen> positionList = new List<Quyen>();
        private TaiKhoan accountFromForm;

        public GUI_Account()
        {
            InitializeComponent();
        }

        private void UpdateDgv(List<TaiKhoan> accountList)
        {
            dgvAccount.DataSource = accountList.Select(x => new { x.TenDangNhap, x.MatKhau, x.Email, Quyen = x.Quyen.Ten }).ToList();
        }

        private void GUI_Account_Load(object sender, System.EventArgs e)
        {
            positionList = busPosition.GetPositions();
            cboPosition.DataSource = positionList;
            cboPosition.ValueMember = "Ma";
            cboPosition.DisplayMember = "Ten";

            accountList = busAccount.GetAccounts();
            UpdateDgv(accountList);
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string un = dgvAccount[0, e.RowIndex].Value.ToString();
            TaiKhoan a = accountList.SingleOrDefault(x => x.TenDangNhap == un);
            txtUn.Text = un;
            txtPw.Text = a.MatKhau;
            txtEmail.Text = a.Email;
            cboPosition.SelectedValue = a.MaQuyen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(accountList.Where(x => x.TenDangNhap.ToLower().Contains(txtSearch.Text)).ToList());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtUn.Clear();
            txtPw.Clear();
            txtEmail.Clear();
            cboPosition.SelectedIndex = 0;
            UpdateDgv(accountList);
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

        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDgv(accountList
                .Where(x => x.MaQuyen == cboPosition.SelectedValue.ToString()).ToList());
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetAccountFromForm();
            if (accountFromForm != null)
            {
                if (accountList.Where(x => x.TenDangNhap == accountFromForm.TenDangNhap).Count() == 0)
                {
                    if (accountFromForm.MatKhau.Length >= 6)
                    {
                        if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            busAccount.Add(accountFromForm);
                            MessageBox.Show("Thêm thành công!");
                            accountList.Add(accountFromForm);
                            UpdateDgv(accountList);
                        }
                    }
                    else MessageBox.Show("Mật khẩu tối thiểu 6 ký tự!");
                }
                else MessageBox.Show("Tên tài khoản đã tồn tại!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetAccountFromForm();
            if (accountFromForm != null)
            {
                TaiKhoan account = accountList.SingleOrDefault(x => x.TenDangNhap == accountFromForm.TenDangNhap);
                if (account != null)
                {
                    if (accountFromForm.MatKhau.Length >= 6)
                    {
                        if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            busAccount.Update(accountFromForm);
                            MessageBox.Show("Sửa thông tin thành công!");
                            UpdateDgv(accountList);
                        }
                    }
                    else MessageBox.Show("Mật khẩu tối thiểu 6 ký tự!");
                }
                else MessageBox.Show("Tên đăng nhập không tồn tại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkTextBox(txtUn))
            {
                if (MessageBox.Show($"Xác nhận xoá tài khoản '{txtUn.Text}'", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    TaiKhoan a = accountList.SingleOrDefault(x => x.TenDangNhap == txtUn.Text);
                    busAccount.Delete(a);
                    MessageBox.Show("Xoá thành công!");
                    accountList.Remove(a);
                    UpdateDgv(accountList);
                }
            }
            else MessageBox.Show("Chưa có tài khoản nào được chọn!");
        }

        private void txtUn_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
