using BUS;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Staff : Form
    {
        private BUS_Staff busStaff = new BUS_Staff();
        private BUS_Position busPosition = new BUS_Position();

        private List<NhanVien> staffList = new List<NhanVien>();
        private List<Quyen> positionList = new List<Quyen>();
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
            positionList = busPosition.GetPositions();
            cboPosition.DataSource = positionList;
            cboPosition.ValueMember = "Ma";
            cboPosition.DisplayMember = "Ten";

            staffList = busStaff.GetStaffs();
            UpdateDgv(staffList);
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string staffID = dgvStaff[0, e.RowIndex].Value.ToString();
            NhanVien s = staffList.SingleOrDefault(x => x.Ma == staffID);
            txtID.Text = staffID;
            txtName.Text = s.Ten;
            txtGender.Text = s.GioiTinh;
            txtPhone.Text = s.SDT;
            txtEmail.Text = s.Email;
            txtAddress.Text = s.DiaChi;
            cboPosition.SelectedValue = s.MaQuyen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(staffList.Where(x => x.Ten.ToLower().Contains(txtSearch.Text)).ToList());
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
            cboPosition.SelectedIndex = -1;
            UpdateDgv(staffList);
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
            if (cboPosition.SelectedIndex != -1)
            {
                UpdateDgv(staffList
                    .Where(x => x.MaQuyen == cboPosition.SelectedValue.ToString()).ToList());
            }
        }

        private bool checkPhone(string phone)
        {
            return Regex.Match(phone, @"^\d{10}$").Success;
        }

        private bool checkEmail(string email)
        {
            return Regex.Match(email, @"^([\w\.-]+)@([\w-]+)((\.(\w){2,3})+)$").Success;
        }

        private void GetStaffFromForm()
        {
            if (checkTextBox(txtID) && checkTextBox(txtName) && checkTextBox(txtGender) && checkTextBox(txtPhone) && checkTextBox(txtEmail) && checkTextBox(txtAddress))
            {
                if (checkPhone(txtPhone.Text))
                {
                    if (checkEmail(txtEmail.Text))
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
                if (staffList.Where(x => x.Ma == staffFromForm.Ma).Count() == 0)
                {
                    if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        busStaff.Add(staffFromForm);
                        MessageBox.Show("Thêm thành công!");
                        staffList = busStaff.GetStaffs();
                        UpdateDgv(staffList);
                    }
                }
                else MessageBox.Show("Mã nhân viên đã tồn tại!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetStaffFromForm();
            if (staffFromForm != null)
            {
                NhanVien staff = staffList.SingleOrDefault(x => x.Ma == staffFromForm.Ma);
                if (staff != null)
                {
                    if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        busStaff.Update(staffFromForm);
                        MessageBox.Show("Sửa thông tin thành công!");
                        staffList = busStaff.GetStaffs();
                        UpdateDgv(staffList);
                    }
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
                    NhanVien a = staffList.SingleOrDefault(x => x.Ma == txtID.Text);
                    busStaff.Delete(a);
                    MessageBox.Show("Xoá thành công!");
                    staffList = busStaff.GetStaffs();
                    UpdateDgv(staffList);
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
