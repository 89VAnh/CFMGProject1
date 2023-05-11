using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillAtShop
    {
        private DAL_BillAtShop dalBillAtShop = new DAL_BillAtShop();

        public List<HDTaiQuan> GetAll()
        {
            return dalBillAtShop.GetAll();
        }

        public HDTaiQuan GetByID(int id)
        {
            return dalBillAtShop.GetByID(id);
        }

        public int GetNewID()
        {
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public HDTaiQuan GetBillAtShopByTableID(int tableID)
        {
            return GetAll().SingleOrDefault(x => x.MaBan == tableID && x.ThoiGianRa == null);
        }

        public List<HDTaiQuan> GetBillTakeAwayUnPaid()
        {
            return GetAll().Where(x => x.MaBan == null && x.ThoiGianRa == null).ToList();
        }

        public void SwapTable(int oldTableID, int newTableID)
        {
            HDTaiQuan b = GetBillAtShopByTableID(oldTableID);
            b.MaBan = newTableID;
            Update(b);
        }

        public void Add(HDTaiQuan billAtShop)
        {
            dalBillAtShop.Add(billAtShop);
        }

        public bool Update(HDTaiQuan billAtShop)
        {
            if (GetByID(billAtShop.Ma) != null)
            {
                dalBillAtShop.Update(billAtShop);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            HDTaiQuan bill = GetByID(id);
            if (bill != null)
            {
                dalBillAtShop.Delete(bill);
                return true;
            }
            return false;
        }
    }
}