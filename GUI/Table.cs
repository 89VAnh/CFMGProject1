using DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Table : UserControl
    {
        private string status = "Trống";

        public Table(Ban t, EventHandler table_Click)
        {
            InitializeComponent();
            this.btnTable.Tag = t.Ma;
            this.btnTable.Text = t.Ten;
            UpdateStatus(t.TrangThai);
            this.btnTable.Click += table_Click;
        }

        public string GetStatus()
        { return status; }

        public void UpdateStatus(string status)
        {
            this.status = status;
            string s = "";
            switch (status)
            {
                case "Có người": s = "table"; break;
                case "Trống": s = "tableEmpty"; break;
                default: break;
            }

            this.btnTable.Image = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.Length - 9) + "Resources/" + s + ".png");
        }
    }
}