using BUS;
using DAL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Main : Form
    {
        public GUI_Main()
        {
            InitializeComponent();
        }

        private void GUI_Main_Load(object sender, System.EventArgs e)
        {
            TaiKhoan currentAccount = BUS_Account.currentAccount;
            lblName.Text = currentAccount.TenDangNhap;
            lblPosition.Text = currentAccount.Quyen.Ten;
            if (currentAccount.Quyen.Ten == "Nhân viên")
            {
                btnManage.Visible = false;
                pnlManage.Visible = false;
            }
        }

        private void timerTime_Tick(object sender, System.EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            pnlBill.Visible = !pnlBill.Visible;
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            pnlManage.Visible = !pnlManage.Visible;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuât không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BUS_Account.currentAccount = null;
                this.Hide();
                GUI_Login f = new GUI_Login();
                f.ShowDialog();
                this.Close();
            }
        }

        private void btnBillAtShop_Click(object sender, EventArgs e)
        {
            GUI_BillAtShop frm = new GUI_BillAtShop();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnBillTakeAway_Click(object sender, EventArgs e)
        {
            GUI_BillTakeAway frm = new GUI_BillTakeAway();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnBillDelivery_Click(object sender, EventArgs e)
        {
            GUI_BillDelivery frm = new GUI_BillDelivery();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            GUI_Customer frm = new GUI_Customer();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            GUI_Account frm = new GUI_Account();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            GUI_Product frm = new GUI_Product();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            GUI_Table frm = new GUI_Table();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            GUI_Staff frm = new GUI_Staff();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            GUI_CategoryProduct frm = new GUI_CategoryProduct();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            GUI_Info frm = new GUI_Info();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            GUI_Bills frm = new GUI_Bills();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            GUI_Statistic frm = new GUI_Statistic();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }
}