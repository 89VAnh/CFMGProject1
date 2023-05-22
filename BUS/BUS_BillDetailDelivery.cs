using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDetailDelivery
    {
        private List<CTHDGiaoHang> billDetailDeliveries = new List<CTHDGiaoHang>();
        private BUS_BillDelivery busBillDelivery = new BUS_BillDelivery();
        private DAL_BillDetailDelivery dalBillDetailDelivery = new DAL_BillDetailDelivery();

        public bool Add(int billID, int productID, int amount, string note)
        {
            if (busBillDelivery.GetByID(billID) != null)
            {
                CTHDGiaoHang billDetailDelivery = GetAll().SingleOrDefault(x => x.MaHD == billID && x.MaSP == productID);
                if (billDetailDelivery == null)
                {
                    CTHDGiaoHang newBillDetail = new CTHDGiaoHang { Ma = GetNewID(), MaHD = billID, MaSP = productID, SoLuong = amount, GhiChu = note };
                    dalBillDetailDelivery.Add(newBillDetail);
                }
                else
                {
                    AddAmount(billDetailDelivery, amount, note);
                }

                return true;
            }
            else return false;
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

        public bool Delete(int id)
        {
            CTHDGiaoHang bd = GetByID(id);
            if (bd != null)
            {
                dalBillDetailDelivery.Delete(bd);
                return true;
            }
            return false;
        }

        public List<CTHDGiaoHang> GetAll()
        {
            return dalBillDetailDelivery.GetAll();
        }

        public List<CTHDGiaoHang> GetBillDetailsByBillID(int id)
        {
            return GetAll().Where(x => x.MaHD == id).ToList();
        }

        public CTHDGiaoHang GetByID(int id)
        {
            return dalBillDetailDelivery.GetByID(id);
        }

        public int GetNewID()
        {
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public bool Update(CTHDGiaoHang billDetail)
        {
            if (GetByID(billDetail.Ma) != null)
            {
                dalBillDetailDelivery.Update(billDetail);
                return true;
            }
            return false;
        }
    }
}