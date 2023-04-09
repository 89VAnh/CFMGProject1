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
        BUS_Table busTable = new BUS_Table();
        List<Ban> tableList;
        int selectedTableID = 0;
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
            tableList = busTable.GetTableCoffees();
            UpdateDgv(tableList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(tableList.Where(x => x.Ten.ToLower().Contains(txtSearch.Text)).ToList());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedTableID = (int)dgvTable.SelectedRows[0].Cells[0].Value;
            txtName.Text = dgvTable.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            UpdateDgv(tableList);
        }


        private string getTableStatus(int tableID)
        {
            return tableList.SingleOrDefault(x => x.Ma == selectedTableID).TrangThai;

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

                    tableList.Add(newT);
                    UpdateDgv(tableList);
                    MessageBox.Show("Thêm bàn thành công!");
                }
            }
            else MessageBox.Show("Vui lòng nhập tên bàn");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTableID > 0)
            {
                if (txtName.Text.Length > 0)
                {
                    if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Ban newTable = new Ban
                        {
                            Ma = selectedTableID,
                            Ten = txtName.Text,
                            TrangThai = getTableStatus(selectedTableID)
                        };
                        busTable.Update(newTable);
                        UpdateDgv(tableList);
                        MessageBox.Show("Sửa tên bàn thành công!");
                    }
                }
                else MessageBox.Show("Vui lòng nhập tên bàn");
            }
            else MessageBox.Show("Vui lòng chọn 1 bàn!", "Thao tác không hợp lệ");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTableID > 0)
            {
                if (getTableStatus(selectedTableID) == "Trống")
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá bàn này không?", "Cẩn thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Ban t = tableList
                            .SingleOrDefault(x => x.Ma == selectedTableID);
                        busTable.Delete(t);
                        tableList.Remove(t);
                        UpdateDgv(tableList);
                        MessageBox.Show("Xoá bàn thành công!");
                    }
                }
                else MessageBox.Show("Không cho phép xoá bàn có người!");
            }
            else MessageBox.Show("Vui lòng chọn 1 bàn!", "Thao tác không hợp lệ");
        }

    }
}
