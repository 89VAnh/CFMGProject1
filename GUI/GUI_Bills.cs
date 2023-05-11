using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Bills : Form
    {
        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();
        private BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();
        private BUS_BillDetailAtShop busBillDetailAtShop = new BUS_BillDetailAtShop();
        private BUS_BillDetailDelivery busBillDetailDelivery = new BUS_BillDetailDelivery();

        private List<HDTaiQuan> billAtShopes = new List<HDTaiQuan>();
        private List<HDTaiQuan> billTakeAways = new List<HDTaiQuan>();
        private List<HDGiaoHang> billDeliveries = new List<HDGiaoHang>();

        public GUI_Bills()
        {
            InitializeComponent();
        }

        private void UpdateDgvBill1(List<HDTaiQuan> bills)
        {
            dgvBill1.DataSource = bills.Select(x => new { x.Ma, TenBan = x.Ban.Ten, x.MaNV, x.MaKH, x.GiamGia, x.TongTien, x.ThoiGianVao, x.ThoiGianRa }).ToList();
        }

        private void UpdateDgvBill2(List<HDTaiQuan> bills)
        {
            dgvBill2.DataSource = bills.Select(x => new { x.Ma, x.MaNV, x.MaKH, x.GiamGia, x.TongTien, x.ThoiGianVao, x.ThoiGianRa }).ToList();
        }

        private void UpdateDgvBill3(List<HDGiaoHang> bills)
        {
            dgvBill3.DataSource = bills.Select(x => new { x.Ma, x.MaKH, x.GiamGia, x.TongTien, x.DiaChi, x.ThoiGianNhan }).ToList();
        }

        private void GUI_Bills_Load(object sender, System.EventArgs e)
        {
            DateTime today = DateTime.Now;
            dtpFrom1.Value = today;
            dtpFrom2.Value = today;
            dtpFrom3.Value = today;
            dtpTo1.Value = today;
            dtpTo2.Value = today;
            dtpTo3.Value = today;

            billAtShopes = busBillAtShop.GetAll().Where(x => x.MaBan != null).ToList();
            UpdateDgvBill1(billAtShopes);

            billTakeAways = busBillAtShop.GetAll().Where(x => x.MaBan == null).ToList();
            UpdateDgvBill2(billTakeAways);

            billDeliveries = busBillDelivery.GetAll();
            UpdateDgvBill3(billDeliveries);
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpFrom1.Value, dtpTo1.Value) <= 0)
            {
                UpdateDgvBill1(billAtShopes.Where(x => x.ThoiGianRa >= dtpFrom1.Value && x.ThoiGianRa <= dtpTo1.Value).ToList());
            }
            else MessageBox.Show("Khoảng thời gian được chọn không hợp lệ!");
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            UpdateDgvBill1(billAtShopes);
            dtpFrom1.Value = DateTime.Now;
            dtpTo1.Value = DateTime.Now;
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpFrom2.Value, dtpTo2.Value) <= 0)
            {
                UpdateDgvBill2(billTakeAways.Where(x => x.ThoiGianRa >= dtpFrom2.Value && x.ThoiGianRa <= dtpTo2.Value).ToList());
            }
            else MessageBox.Show("Khoảng thời gian được chọn không hợp lệ!");
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            UpdateDgvBill2(billAtShopes);
            dtpFrom2.Value = DateTime.Now;
            dtpTo2.Value = DateTime.Now;
        }

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpFrom3.Value, dtpTo3.Value) <= 0)
            {
                UpdateDgvBill3(billDeliveries.Where(x => x.ThoiGianNhan >= dtpFrom3.Value && x.ThoiGianNhan <= dtpTo3.Value).ToList());
            }
            else MessageBox.Show("Khoảng thời gian được chọn không hợp lệ!");
        }

        private void btnRefresh3_Click(object sender, EventArgs e)
        {
            UpdateDgvBill3(billDeliveries);
            dtpFrom3.Value = DateTime.Now;
            dtpTo3.Value = DateTime.Now;
        }

        private void btnExcel1_Click(object sender, EventArgs e)
        {
            //if (dgvBill1.Rows.Count > 0)
            //{
            //    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

            //    XcelApp.Application.Workbooks.Add(Type.Missing);

            //    for (int i = 1; i < dgvBill1.Columns.Count + 1; i++)
            //    {
            //        XcelApp.Cells[1, i] = dgvBill1.Columns[i - 1].HeaderText;
            //    }
            //    for (int i = 0; i < dgvBill1.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgvBill1.Columns.Count; j++)
            //        {
            //            var value = dgvBill1.Rows[i].Cells[j].Value;
            //            if (value != null)
            //                XcelApp.Cells[i + 2, j + 1] = value.ToString();
            //        }
            //    }
            //    XcelApp.Columns.AutoFit();
            //    XcelApp.Visible = true;
            //}
        }

        private void btnExcel2_Click(object sender, EventArgs e)
        {
            //if (dgvBill2.Rows.Count > 0)
            //{
            //    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

            //    XcelApp.Application.Workbooks.Add(Type.Missing);

            //    for (int i = 1; i < dgvBill2.Columns.Count + 1; i++)
            //    {
            //        XcelApp.Cells[1, i] = dgvBill2.Columns[i - 1].HeaderText;
            //    }
            //    for (int i = 0; i < dgvBill2.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgvBill2.Columns.Count; j++)
            //        {
            //            var value = dgvBill2.Rows[i].Cells[j].Value;
            //            if (value != null)
            //                XcelApp.Cells[i + 2, j + 1] = value.ToString();
            //        }
            //    }
            //    XcelApp.Columns.AutoFit();
            //    XcelApp.Visible = true;
            //}
        }

        private void btnExcel3_Click(object sender, EventArgs e)
        {
            //if (dgvBill3.Rows.Count > 0)
            //{
            //    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

            //    XcelApp.Application.Workbooks.Add(Type.Missing);

            //    for (int i = 1; i < dgvBill3.Columns.Count + 1; i++)
            //    {
            //        XcelApp.Cells[1, i] = dgvBill3.Columns[i - 1].HeaderText;
            //    }
            //    for (int i = 0; i < dgvBill3.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgvBill3.Columns.Count; j++)
            //        {
            //            var value = dgvBill3.Rows[i].Cells[j].Value;
            //            if (value != null)
            //                XcelApp.Cells[i + 2, j + 1] = value.ToString();
            //        }
            //    }
            //    XcelApp.Columns.AutoFit();
            //    XcelApp.Visible = true;
            //}
        }
    }
}