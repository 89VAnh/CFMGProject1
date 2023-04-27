using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Table
    {
        private DAL_Table dalTable = new DAL_Table();
        private List<Ban> tableList = new List<Ban>();

        public List<Ban> GetTableCoffees()
        {
            tableList = dalTable.GetTableCoffees();
            return tableList;
        }

        public int GetNewID()
        {
            return GetTableCoffees().Count() > 0 ? 1 : GetTableCoffees().Last().Ma + 1;
        }

        public void Add(Ban table)
        {
            dalTable.Add(table);
        }

        public void Update(Ban table)
        {
            dalTable.Update(table);
        }

        public void Delete(Ban table)
        {
            dalTable.Delete(table);
        }

        public void setTableStatus(int tableID, string status)
        {
            Ban tb = tableList.SingleOrDefault(x => x.Ma == tableID);
            if (status != tb.TrangThai)
            {
                tb.TrangThai = status;
                Update(tb);
            }
        }
    }
}
