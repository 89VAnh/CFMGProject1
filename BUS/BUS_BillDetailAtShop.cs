using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDetailAtShop
    {
        DAL_BillDetailAtShop dalBillDetailAtShop = new DAL_BillDetailAtShop();
        BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();

        public List<CTHDTaiQuan> GetBillDetailAtShopes()
        {
            return dalBillDetailAtShop.GetBillDetailAtShopes();
        }
        public List<CTHDTaiQuan> GetBillDetailByBillID(int id)
        {
            return GetBillDetailAtShopes().Where(x => x.MaHD == id).ToList();
        }
        public List<CTHDTaiQuan> GetBillDetailAtShopesInTable(int tableID)
        {
            HDTaiQuan billAtShop = busBillAtShop.GetBillAtShopByTableID(tableID);
            if (billAtShop != null)
                return GetBillDetailByBillID(billAtShop.Ma);
            else return new List<CTHDTaiQuan>();
        }

        public int GetNewID()
        {
            return dalBillDetailAtShop.GetNewID();
        }
        public void AddAmount(CTHDTaiQuan bd, int amount, string note)
        {
            bd.SoLuong += amount;
            if (string.IsNullOrWhiteSpace(bd.GhiChu))
                bd.GhiChu = note;
            else
                bd.GhiChu += ", " + note;
            dalBillDetailAtShop.Update(bd);
        }
        public void Add(CTHDTaiQuan billAtShopInfo)
        {
            dalBillDetailAtShop.Add(billAtShopInfo);
        }
        public void Update(CTHDTaiQuan billAtShopInfo)
        {
            dalBillDetailAtShop.Update(billAtShopInfo);
        }
        public void Delete(CTHDTaiQuan billAtShopInfo)
        {
            dalBillDetailAtShop.Delete(billAtShopInfo);
        }
    }
}
