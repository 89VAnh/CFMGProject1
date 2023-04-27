﻿using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDetailDelivery
    {
        private DAL_BillDetailDelivery dalBillDetailDelivery = new DAL_BillDetailDelivery();
        private List<CTHDGiaoHang> billDetailDeliveries = new List<CTHDGiaoHang>();

        public List<CTHDGiaoHang> GetBillDetailDeliveries()
        {
            billDetailDeliveries = dalBillDetailDelivery.GetBillDetailDeliveries();
            return billDetailDeliveries;
        }

        public int GetNewID()
        {
            return GetBillDetailDeliveries().Count() == 0 ? 1 : GetBillDetailDeliveries().Last().Ma + 1;
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
