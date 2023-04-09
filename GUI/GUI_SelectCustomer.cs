using BUS;
using DAL;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_SelectCustomer : Form
    {
        BUS_Customer busCustomer = new BUS_Customer();
        BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();
        int selectedCustomerID = 0;
        HDTaiQuan _billAtShop = null;

        public GUI_SelectCustomer(HDTaiQuan billAtShop)
        {
            InitializeComponent();
            _billAtShop = billAtShop;
        }

        private void GUI_SelectCustomer_Load(object sender, System.EventArgs e)
        {
            dgvCustomer.DataSource = busCustomer.GetCustomers().Select(x => new { x.Ma, x.Ten, x.GioiTinh, x.SDT, x.Email, x.DiaChi }).ToList();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedCustomerID = (int)dgvCustomer[1, e.RowIndex].Value;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            _billAtShop.MaKH = selectedCustomerID;
            busBillAtShop.Update(_billAtShop);
        }
    }
}
