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
    public partial class GUI_Customer : Form
    {
        private BUS_Customer busCustomer = new BUS_Customer();

        private KhachHang customerFromForm;
        private string selectedCustomerID = "";

        public GUI_Customer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetCustomerFromForm();
            if (customerFromForm != null)
            {
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busCustomer.Add(customerFromForm);
                    UpdateDgv(busCustomer.GetAll());
                    MessageBox.Show("Thêm thành công!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(selectedCustomerID))
            {
                if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busCustomer.Delete(selectedCustomerID))
                    {
                        UpdateDgv(busCustomer.GetAll());
                        MessageBox.Show("Xoá thành công!");
                    }
                    else MessageBox.Show("Mã khách hàng được chọn không hợp lệ!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetCustomerFromForm();
            if (customerFromForm != null)
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busCustomer.Update(customerFromForm))
                    {
                        UpdateDgv(busCustomer.GetAll());
                        MessageBox.Show("Sửa thông tin thành công!");
                    }
                    else MessageBox.Show("Mã khách hàng không tồn tại!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            txtGender.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            UpdateDgv(busCustomer.GetAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(busCustomer.SearchCustomerByName(txtSearch.Text));
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

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedCustomerID = dgvCustomer[0, e.RowIndex].Value.ToString();
                txtName.Text = dgvCustomer[1, e.RowIndex].Value.ToString();
                txtGender.Text = dgvCustomer[2, e.RowIndex].Value.ToString();
                txtPhone.Text = dgvCustomer[3, e.RowIndex].Value.ToString();
                txtEmail.Text = dgvCustomer[4, e.RowIndex].Value.ToString();
                txtAddress.Text = dgvCustomer[5, e.RowIndex].Value.ToString();
            }
            catch { }
        }

        private void GetCustomerFromForm()
        {
            if (checkTextBox(txtName) && checkTextBox(txtGender) && checkTextBox(txtPhone) && checkTextBox(txtEmail) && checkTextBox(txtAddress))
            {
                if (Tools.CheckPhone(txtPhone.Text))
                {
                    if (Tools.CheckEmail(txtEmail.Text))
                    {
                        customerFromForm = new KhachHang
                        {
                            Ma = selectedCustomerID,
                            Ten = txtName.Text,
                            GioiTinh = txtGender.Text,
                            SDT = txtPhone.Text,
                            Email = txtEmail.Text,
                            DiaChi = txtAddress.Text,
                        };
                    }
                    else
                    {
                        customerFromForm = null;
                        MessageBox.Show("Email không đúng định dạng");
                    }
                }
                else
                {
                    customerFromForm = null;
                    MessageBox.Show("Số điện thoại là dãy số có 10 chữ số");
                }
            }
            else
            {
                customerFromForm = null;
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void GUI_Customer_Load(object sender, EventArgs e)
        {
            UpdateDgv(busCustomer.GetAll());
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtGender_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void UpdateDgv(List<KhachHang> customerList)
        {
            dgvCustomer.DataSource = customerList.Select(x => new { x.Ma, x.Ten, x.GioiTinh, x.SDT, x.Email, x.DiaChi }).ToList();
        }
    }
}