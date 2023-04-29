using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillAtShop
    {
        private DAL_BillAtShop dalBillAtShop = new DAL_BillAtShop();

        public List<HDTaiQuan> GetBillAtShopes()
        {
            return dalBillAtShop.GetBillAtShopes();
        }

        public int GetNewID()
        {
            return GetBillAtShopes().Count() == 0 ? 1 : GetBillAtShopes().Last().Ma + 1;
        }
        public HDTaiQuan GetBillAtShopByTableID(int tableID)
        {
            return GetBillAtShopes().SingleOrDefault(x => x.MaBan == tableID && x.ThoiGianRa == null);
        }

        public List<HDTaiQuan> GetBillTakeAwayUnPaid()
        {
            var bills = GetBillAtShopes();
            return GetBillAtShopes().Where(x => x.MaBan == null && x.ThoiGianRa == null).ToList();
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

        public void Update(HDTaiQuan billAtShop)
        {
            dalBillAtShop.Update(billAtShop);
        }

        public void Delete(HDTaiQuan billAtShop)
        {
            dalBillAtShop.Delete(billAtShop);
        }
    }
}
