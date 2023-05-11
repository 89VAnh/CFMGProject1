using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_BillDelivery
    {
        private DAL_BillDelivery dalBillDelivery = new DAL_BillDelivery();
        private List<HDGiaoHang> billDeliveries = new List<HDGiaoHang>();

        public List<HDGiaoHang> GetAll()
        {
            return dalBillDelivery.GetAll();
        }

        public List<HDGiaoHang> GetBillDeliveriesUnPaid()
        {
            return GetAll().Where(x => x.ThoiGianNhan == null).ToList();
        }

        public HDGiaoHang GetByID(int id)
        {
            return dalBillDelivery.GetByID(id);
        }

        public string GetDiscount(string discount, int discountType)
        {
            if (discount != "0")
            {
                switch (discountType)
                {
                    case 0: discount += "000 đ"; break;
                    case 1: discount += " %"; break;
                    default: break;
                }
            }
            return discount;
        }

        public int GetNewID()
        {
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public void Add(HDGiaoHang billDelivery)
        {
            billDelivery.Ma = GetNewID();
            dalBillDelivery.Add(billDelivery);
        }

        public bool Update(HDGiaoHang billDelivery)
        {
            if (dalBillDelivery.GetByID(billDelivery.Ma) != null)
            {
                dalBillDelivery.Update(billDelivery);
                return true;
            }
            return false;
        }

        public bool Delete(int billId)
        {
            HDGiaoHang b = dalBillDelivery.GetByID(billId);
            if (b != null)
            {
                dalBillDelivery.Delete(b);
                return true;
            }
            return false;
        }
    }
}