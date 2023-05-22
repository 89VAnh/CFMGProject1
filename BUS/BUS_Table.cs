using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Table
    {
        private DAL_Table dalTable = new DAL_Table();

        public void Add(Ban table)
        {
            dalTable.Add(table);
        }

        public bool Delete(int id)
        {
            Ban t = GetByID(id);
            if (t != null)
            {
                dalTable.Delete(t);
                return true;
            }
            return false;
        }

        public List<Ban> GetAll()
        {
            return dalTable.GetAll();
        }

        public Ban GetByID(int id)
        {
            return dalTable.GetByID(id);
        }

        public List<Ban> GetEmptyTables()
        {
            return GetAll().Where(x => x.TrangThai == "Trống").ToList();
        }

        public int GetNewID()
        {
            return GetAll().Count() > 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public string GetTableStatus(int tableID)
        {
            return GetByID(tableID).TrangThai;
        }

        public List<Ban> SearchTableByName(string keyword)
        {
            return GetAll().Where(x => x.Ten.ToLower().Contains(keyword)).ToList();
        }

        public void setTableStatus(int tableID, string status)
        {
            Ban tb = GetByID(tableID);
            if (status != tb.TrangThai)
            {
                tb.TrangThai = status;
                Update(tb);
            }
        }

        public bool Update(Ban table)
        {
            if (GetByID(table.Ma) != null)
            {
                dalTable.Update(table);
                return true;
            }
            return false;
        }
    }
}