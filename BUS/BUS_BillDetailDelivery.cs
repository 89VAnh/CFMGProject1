using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDetailDelivery
    {
        DAL_BillDetailDelivery dalBillDetailDelivery = new DAL_BillDetailDelivery();
        List<CTHDGiaoHang> billDetailDeliveries = new List<CTHDGiaoHang>();
        public List<CTHDGiaoHang> GetBillDetailDeliveries()
        {
            billDetailDeliveries = dalBillDetailDelivery.GetBillDetailDeliveries();
            return billDetailDeliveries;
        }
        public int GetNewID()
        {
            billDetailDeliveries = GetBillDetailDeliveries();
            if (billDetailDeliveries.Count == 0) return 1;
            else return billDetailDeliveries.Last().Ma + 1;
        }
        public void AddAmount(CTHDGiaoHang bd, int amount, string note)
        {
            bd.SoLuong += amount;
            if (string.IsNullOrWhiteSpace(bd.GhiChu))
                bd.GhiChu = note;
            else
                bd.GhiChu += ", " + note;
            dalBillDetailDelivery.Update(bd);
        }
        public void Add(CTHDGiaoHang billDetail)
        {
            billDetail.Ma = GetNewID();
            dalBillDetailDelivery.Add(billDetail);
        }
        public void Update(CTHDGiaoHang billDetail)
        {
            dalBillDetailDelivery.Update(billDetail);
        }
        public void Delete(CTHDGiaoHang billDetail)
        {
            dalBillDetailDelivery.Delete(billDetail);
        }
    }
}
