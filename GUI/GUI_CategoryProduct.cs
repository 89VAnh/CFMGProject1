using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_CategoryProduct : Form
    {
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();

        private int selectedCategoryProductID = 0;

        public GUI_CategoryProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtName.Text))
            {
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DanhMucSanPham newCP = new DanhMucSanPham
                    {
                        Ten = txtName.Text
                    };
                    busCategoryProduct.Add(newCP);
                    UpdateDgv(busCategoryProduct.GetAll());
                    MessageBox.Show("Thêm danh mục món thành công!");
                }
            }
            else MessageBox.Show("Vui lòng nhập tên danh mục!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryProductID > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục món này không?\n Các món trong danh mục này sẽ bị xoá", "Cẩn thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busCategoryProduct.Delete(selectedCategoryProductID);
                    UpdateDgv(busCategoryProduct.GetAll());
                    MessageBox.Show("Xoá thành công!");
                }
            }
            else MessageBox.Show("Vui lòng chọn 1 danh mục đồ ăn!", "Thao tác không hợp lệ");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryProductID > 0)
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DanhMucSanPham cp = new DanhMucSanPham
                    {
                        Ma = selectedCategoryProductID,
                        Ten = txtName.Text
                    };
                    busCategoryProduct.Update(cp);
                    UpdateDgv(busCategoryProduct.GetAll());
                    MessageBox.Show("Sửa danh mục món thành công!");
                }
            }
            else MessageBox.Show("Vui lòng chọn 1 danh mục đồ ăn!", "Thao tác không hợp lệ");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            UpdateDgv(busCategoryProduct.GetAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(busCategoryProduct.SearchCategoryProductsByName(txtSearch.Text));
        }

        private void dgvCategoryProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedCategoryProductID = (int)dgvCategoryProduct[0, e.RowIndex].Value;
            txtName.Text = dgvCategoryProduct[1, e.RowIndex].Value.ToString();
        }

        private void GUI_CategoryProduct_Load(object sender, EventArgs e)
        {
            UpdateDgv(busCategoryProduct.GetAll());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void UpdateDgv(List<DanhMucSanPham> categoryProductList)
        {
            dgvCategoryProduct.DataSource = categoryProductList.Select(x => new { x.Ma, x.Ten, SoLuong = x.SanPhams.Count }).ToList();
        }
    }
}