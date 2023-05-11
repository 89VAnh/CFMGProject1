using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Table : Form
    {
        private BUS_Table busTable = new BUS_Table();
        private int selectedTableID = 0;

        public GUI_Table()
        {
            InitializeComponent();
        }

        private void UpdateDgv(List<Ban> tables)
        {
            dgvTable.DataSource = tables.Select(x => new { x.Ma, x.Ten, x.TrangThai }).ToList();
        }

        private void GUI_Table_Load(object sender, EventArgs e)
        {
            UpdateDgv(busTable.GetAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(busTable.GetAll());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedTableID = (int)dgvTable[0, e.RowIndex].Value;
            txtName.Text = dgvTable[1, e.RowIndex].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            UpdateDgv(busTable.GetAll());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Ban newT = new Ban
                    {
                        Ma = busTable.GetNewID(),
                        Ten = txtName.Text,
                        TrangThai = "Trống"
                    };
                    busTable.Add(newT);
                    UpdateDgv(busTable.GetAll());
                    MessageBox.Show("Thêm bàn thành công!");
                }
            }
            else MessageBox.Show("Vui lòng nhập tên bàn!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Ban newTable = new Ban
                    {
                        Ma = selectedTableID,
                        Ten = txtName.Text,
                        TrangThai = busTable.GetTableStatus(selectedTableID)
                    };
                    if (busTable.Update(newTable))
                    {
                        UpdateDgv(busTable.GetAll());
                        MessageBox.Show("Sửa tên bàn thành công!");
                    }
                    else MessageBox.Show("Mã bàn được chọn không hợp lệ!", "Thao tác không hợp lệ");
                }
                else MessageBox.Show("Vui lòng nhập tên bàn");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTableID > 0)
            {
                if (busTable.GetTableStatus(selectedTableID) == "Trống")
                {
                    if (MessageBox.Show($"Bạn có chắc chắn muốn xoá bàn {selectedTableID} không?", "Cẩn thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (busTable.Delete(selectedTableID))
                        {
                            UpdateDgv(busTable.GetAll());
                            MessageBox.Show("Xoá bàn thành công!");
                        }
                        else MessageBox.Show("Mã bàn được chọn không hợp lệ!");
                    }
                }
                else MessageBox.Show("Không cho phép xoá bàn có người!");
            }
            else MessageBox.Show("Vui lòng chọn 1 bàn!", "Thao tác không hợp lệ");
        }
    }
}