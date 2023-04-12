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
    public partial class GUI_Customer : Form
    {
        private BUS_Customer busCustomer = new BUS_Customer();
        private int selectedCustomerID = 0;
        private List<KhachHang> customerList = new List<KhachHang>();
        private KhachHang customerFromForm;

        public GUI_Customer()
        {
            InitializeComponent();
        }

        private void UpdateDgv(List<KhachHang> customerList)
        {
            dgvCustomer.DataSource = customerList.Select(x => new { x.Ma, x.Ten, x.GioiTinh, x.SDT, x.Email, x.DiaChi }).ToList();
        }

        private void GUI_Customer_Load(object sender, EventArgs e)
        {
            customerList = busCustomer.GetCustomers();
            UpdateDgv(customerList);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedCustomerID = Convert.ToInt32(dgvCustomer[0, e.RowIndex].Value.ToString());
                KhachHang c = customerList.SingleOrDefault(x => x.Ma == selectedCustomerID);
                txtName.Text = c.Ten;
                txtGender.Text = c.GioiTinh;
                txtPhone.Text = c.SDT;
                txtEmail.Text = c.Email;
                txtAddress.Text = c.DiaChi;
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(customerList.Where(x => x.Ten.ToLower().Contains(txtSearch.Text)).ToList());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            txtGender.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            UpdateDgv(customerList);
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

        private bool checkPhone(string phone)
        {
            return Regex.Match(phone, @"^\d{10}$").Success;
        }

        private bool checkEmail(string email)
        {
            return Regex.Match(email, @"^([\w\.-]+)@([\w-]+)((\.(\w){2,3})+)$").Success;
        }

        private void GetCustomerFromForm()
        {
            if (checkTextBox(txtName) && checkTextBox(txtGender) && checkTextBox(txtPhone) && checkTextBox(txtEmail) && checkTextBox(txtAddress))
            {
                if (checkPhone(txtPhone.Text))
                {
                    if (checkEmail(txtEmail.Text))
                    {
                        customerFromForm = new KhachHang
                        {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetCustomerFromForm();
            if (customerFromForm != null)
            {
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busCustomer.Add(customerFromForm);
                    MessageBox.Show("Thêm thành công!");
                    GUI_Customer_Load(sender, e);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetCustomerFromForm();
            if (customerFromForm != null)
            {
                KhachHang customer = customerList.SingleOrDefault(x => x.Ma == Convert.ToInt32(selectedCustomerID));
                if (customer != null)
                {
                    if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        customerFromForm.Ma = selectedCustomerID;
                        busCustomer.Update(customerFromForm);
                        MessageBox.Show("Sửa thông tin thành công!");
                        GUI_Customer_Load(sender, e);
                    }
                }
                else MessageBox.Show("Mã nhân viên không tồn tại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KhachHang a = customerList.SingleOrDefault(x => x.Ma == Convert.ToInt32(selectedCustomerID));
                    busCustomer.Delete(a);
                    MessageBox.Show("Xoá thành công!");
                    GUI_Customer_Load(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Chưa có nhân viên nào được chọn!");
            }
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
