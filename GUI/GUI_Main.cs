using BUS;
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
            //sttWelcome.Text = "Xin chào " + BUS_Account.currentAccount.Username;
            //if (BUS_Account.currentAccount.Position.Name == "Nhân viên")
            //{
            //    quảnLýToolStripMenuItem1.Visible = false;
            //}
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, System.EventArgs e)
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

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_Info frm = new GUI_Info();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void hoáĐơnTạiQuánToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_BillAtShop frm = new GUI_BillAtShop();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void danhMụcToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_CategoryProduct frm = new GUI_CategoryProduct();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void thựcĐơnToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_Product frm = new GUI_Product();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void bànToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_Table frm = new GUI_Table();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_Staff frm = new GUI_Staff();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_Account frm = new GUI_Account();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_Customer frm = new GUI_Customer();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void hoáĐơnGiaoHàngToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_BillDelivery frm = new GUI_BillDelivery();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void hoáĐơnMangVềToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GUI_BillTakeAway frm = new GUI_BillTakeAway();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, System.EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, System.EventArgs e)
        {

        }
    }
}
