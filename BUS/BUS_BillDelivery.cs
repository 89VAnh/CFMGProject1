using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDelivery
    {
        private DAL_BillDelivery dalBillDelivery = new DAL_BillDelivery();
        private List<HDGiaoHang> billDeliveries = new List<HDGiaoHang>();

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
            return GetBillDeliveries().Count() == 0 ? 1 : GetBillDeliveries().Last().Ma + 1;
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
