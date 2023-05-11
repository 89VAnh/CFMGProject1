using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GUI
{
    public partial class GUI_Staff : Form
    {
        private BUS_Staff busStaff = new BUS_Staff();
        private BUS_Position busPosition = new BUS_Position();

        private NhanVien staffFromForm;

        public GUI_Staff()
        {
            InitializeComponent();
        }

        private void UpdateDgv(List<NhanVien> staffList)
        {
            dgvStaff.DataSource = staffList.Select(x => new { x.Ma, x.Ten, x.GioiTinh, x.SDT, x.Email, x.DiaChi, ChucVu = x.Quyen.Ten }).ToList();
        }

        private void GUI_Staff_Load(object sender, EventArgs e)
        {
            cboPosition.DataSource = busPosition.GetAll();
            cboPosition.ValueMember = "Ma";
            cboPosition.DisplayMember = "Ten";
            cboPosition.SelectedIndex = 0;

            UpdateDgv(busStaff.GetAll());
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string staffID = dgvStaff[0, e.RowIndex].Value.ToString();
            txtID.Text = dgvStaff[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvStaff[1, e.RowIndex].Value.ToString();
            txtGender.Text = dgvStaff[2, e.RowIndex].Value.ToString();
            txtPhone.Text = dgvStaff[3, e.RowIndex].Value.ToString();
            txtEmail.Text = dgvStaff[4, e.RowIndex].Value.ToString();
            txtAddress.Text = dgvStaff[5, e.RowIndex].Value.ToString();
            cboPosition.SelectedValue = dgvStaff[6, e.RowIndex].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(busStaff.SearchStaffsByName(txtSearch.Text));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtID.Clear();
            txtName.Clear();
            txtGender.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cboPosition.SelectedIndex = 1;
            UpdateDgv(busStaff.GetAll());
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
            if (cboPosition.SelectedIndex > 0)
            {
                UpdateDgv(busStaff.SearchStaffsByPosition(cboPosition.SelectedValue.ToString()));
            }
        }

        private void GetStaffFromForm()
        {
            if (checkTextBox(txtID) && checkTextBox(txtName) && checkTextBox(txtGender) && checkTextBox(txtPhone) && checkTextBox(txtEmail) && checkTextBox(txtAddress))
            {
                if (Tools.CheckPhone(txtPhone.Text))
                {
                    if (Tools.CheckEmail(txtEmail.Text))
                    {
                        if (cboPosition.SelectedIndex >= 1)
                        {
                            staffFromForm = new NhanVien
                            {
                                Ma = txtID.Text,
                                Ten = txtName.Text,
                                GioiTinh = txtGender.Text,
                                SDT = txtPhone.Text,
                                Email = txtEmail.Text,
                                DiaChi = txtAddress.Text,
                                MaQuyen = cboPosition.SelectedValue.ToString()
                            };
                        }
                        else MessageBox.Show("Vui lòng chọn vị trí");
                    }
                    else
                    {
                        staffFromForm = null;
                        MessageBox.Show("Email không đúng định dạng");
                    }
                }
                else
                {
                    staffFromForm = null;
                    MessageBox.Show("Số điện thoại là dãy số có 10 chữ số");
                }
            }
            else
            {
                staffFromForm = null;
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetStaffFromForm();
            if (staffFromForm != null)
            {
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busStaff.Add(staffFromForm))
                    {
                        MessageBox.Show("Thêm thành công!");
                        UpdateDgv(busStaff.GetAll());
                    }
                    else MessageBox.Show("Mã nhân viên đã tồn tại!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetStaffFromForm();
            if (staffFromForm != null)
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busStaff.Update(staffFromForm))
                    {
                        UpdateDgv(busStaff.GetAll());
                        MessageBox.Show("Sửa thông tin thành công!");
                    }
                    else MessageBox.Show("Mã nhân viên không tồn tại");
                }
                else MessageBox.Show("Mã nhân viên không tồn tại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkTextBox(txtID))
            {
                if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busStaff.Delete(txtID.Text))
                    {
                        UpdateDgv(busStaff.GetAll());
                        MessageBox.Show("Xoá thành công!");
                    }
                    else MessageBox.Show("Mã nhân viên không tồn tại");
                }
            }
            else MessageBox.Show("Chưa có nhân viên nào được chọn!");
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtGender_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}