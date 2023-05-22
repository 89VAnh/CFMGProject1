using BUS.CustomExport;
using DAL;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace BUS
{
    public class BUS_BillDelivery
    {
        private DAL_BillDelivery dalBillDelivery = new DAL_BillDelivery();

        public void Add(HDGiaoHang billDelivery)
        {
            billDelivery.Ma = GetNewID();
            dalBillDelivery.Add(billDelivery);
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

        public void ExportBillDeliveryToWord(HDGiaoHang bill, List<CTHDGiaoHang> billDetails, int totalPrice, string templatePath, string exportPath)
        {
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();

            dictionaryData.Add("Ma", bill.Ma.ToString());
            dictionaryData.Add("KhachHang", bill.KhachHang.Ten);
            dictionaryData.Add("DiaChi", bill.DiaChi);
            dictionaryData.Add("ThoiGianNhan", bill.ThoiGianNhan.ToString());
            dictionaryData.Add("TongTienTruocGG", Tools.ConvertToCurrency(totalPrice));
            dictionaryData.Add("GiamGia", bill.GiamGia);
            dictionaryData.Add("TongTien", Tools.ConvertToCurrency((int)bill.TongTien));

            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateBillDeliveryTemplate(exportPath, dictionaryData, billDetails);
        }

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

        public bool Update(HDGiaoHang billDelivery)
        {
            if (dalBillDelivery.GetByID(billDelivery.Ma) != null)
            {
                dalBillDelivery.Update(billDelivery);
                return true;
            }
            return false;
        }
    }
}