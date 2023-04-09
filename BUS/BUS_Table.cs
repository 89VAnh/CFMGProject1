using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Table
    {
        DAL_Table dalTable = new DAL_Table();
        List<Ban> tableList = new List<Ban>();

        public List<Ban> GetTableCoffees()
        {
            tableList = dalTable.GetTableCoffees();
            return tableList;
        }
        public int GetNewID()
        {
            List<Ban> tables = GetTableCoffees();
            if (tables.Count == 0) return 1;
            else return tables.Last().Ma + 1;
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
