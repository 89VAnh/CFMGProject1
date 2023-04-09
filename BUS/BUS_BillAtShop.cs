using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillAtShop
    {
        DAL_BillAtShop dalBillAtShop = new DAL_BillAtShop();
        public List<HDTaiQuan> GetBillAtShops()
        {
            return dalBillAtShop.GetBillAtShops();
        }
        public int GetNewID()
        {
            List<HDTaiQuan> billAtShops = dalBillAtShop.GetBillAtShops();
            if (billAtShops.Count == 0) return 1;
            else return billAtShops.Last().Ma + 1;
        }
        public HDTaiQuan GetBillAtShopByTableID(int tableID)
        {
            return dalBillAtShop.GetBillAtShopByTableID(tableID);
        }
        public List<HDTaiQuan> GetBillTakeAwayUnPaid()
        {
            return GetBillAtShops().Where(x => x.Ban == null && x.ThoiGianRa == null).ToList();
        }
        public void SwapTable(int oldTableID, int newTableID)
        {
            HDTaiQuan b = GetBillAtShopByTableID(oldTableID);
            b.MaBan = newTableID;
            dalBillAtShop.Update(b);
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
