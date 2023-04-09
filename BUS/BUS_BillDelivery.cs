using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDelivery
    {
        DAL_BillDelivery dalBillDelivery = new DAL_BillDelivery();
        List<HDGiaoHang> billDeliveries = new List<HDGiaoHang>();
        public List<HDGiaoHang> GetBillDeliveries()
        {
            billDeliveries = dalBillDelivery.GetBillDeliveries();
            return billDeliveries;
        }
        public List<HDGiaoHang> GetBillDeliveriesUnPaid()
        {
            return GetBillDeliveries().Where(x => x.ThoiGianNhan == null).ToList();
        }
        public int GetNewID()
        {
            billDeliveries = GetBillDeliveries();
            if (billDeliveries.Count == 0) return 1;
            else return billDeliveries.Last().Ma + 1;
        }
        public void Add(HDGiaoHang billDelivery)
        {
            billDelivery.Ma = GetNewID();
            dalBillDelivery.Add(billDelivery);
        }
        public void Update(HDGiaoHang billDelivery)
        {
            dalBillDelivery.Update(billDelivery);
        }
        public void Delete(HDGiaoHang billDelivery)
        {
            dalBillDelivery.Delete(billDelivery);
        }
    }
}
