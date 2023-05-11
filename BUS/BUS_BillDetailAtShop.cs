using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDetailAtShop
    {
        private DAL_BillDetailAtShop dalBillDetailAtShop = new DAL_BillDetailAtShop();
        private BUS_BillAtShop busBillAtShop = new BUS_BillAtShop();

        public List<CTHDTaiQuan> GetAll()
        {
            return dalBillDetailAtShop.GetAll();
        }

        public CTHDTaiQuan GetByID(int id)
        {
            return dalBillDetailAtShop.GetByID(id);
        }

        public List<CTHDTaiQuan> GetBillDetailByBillID(int id)
        {
            return GetAll().Where(x => x.MaHD == id).ToList();
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
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
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

        public void Add(HDTaiQuan billAtShop, int? tableId, int productId, int amount, string note)
        {
            int id;

            if (billAtShop == null)
            {
                id = busBillAtShop.GetNewID();
                busBillAtShop.Add(new HDTaiQuan { Ma = id, MaBan = tableId, ThoiGianVao = DateTime.Now, TongTien = 0 });
            }
            else
                id = billAtShop.Ma;
            CTHDTaiQuan newBillDetail = new CTHDTaiQuan { Ma = GetNewID(), MaHD = id, MaSP = productId, SoLuong = amount, GhiChu = note };

            CTHDTaiQuan billDetailAtShop = GetAll().SingleOrDefault(x => x.MaHD == id && x.MaSP == newBillDetail.MaSP);
            if (billDetailAtShop == null)
            {
                dalBillDetailAtShop.Add(newBillDetail);
            }
            else
            {
                AddAmount(billDetailAtShop, newBillDetail.SoLuong, newBillDetail.GhiChu);
            }
        }

        public bool Update(CTHDTaiQuan billDetailAtShop)
        {
            CTHDTaiQuan bd = GetAll().SingleOrDefault(x => x.Ma == billDetailAtShop.Ma);
            if (bd != null)
            {
                dalBillDetailAtShop.Update(billDetailAtShop);
                return true;
            }
            return false;
        }

        public bool Delete(int billDetailId)
        {
            CTHDTaiQuan bd = GetAll().SingleOrDefault(x => x.Ma == billDetailId);
            if (bd != null)
            {
                dalBillDetailAtShop.Delete(bd);
                return true;
            }
            return false;
        }
    }
}