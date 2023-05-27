using DAL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Table : UserControl
    {
        private string _status = "Trống";

        public Table(Ban t, EventHandler table_Click)
        {
            InitializeComponent();
            this.btnTable.Tag = t.Ma;
            this.btnTable.Text = t.Ten;
            UpdateStatus(t.TrangThai);
            this.btnTable.Click += table_Click;
        }

        public string GetStatus()
        { return _status; }

        public void UpdateStatus(string status)
        {
            _status = status;
            switch (status)
            {
                case "Có người": btnTable.Image = global::GUI.Properties.Resources.table; ; break;
                case "Trống": btnTable.Image = global::GUI.Properties.Resources.tableEmpty; break;
                default: break;
            }
        }
    }
}