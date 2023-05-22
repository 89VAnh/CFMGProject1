using BUS.CustomExport;
using DAL;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace BUS
{
    public class BUS_BillAtShop
    {
        private DAL_BillAtShop dalBillAtShop = new DAL_BillAtShop();

        public void Add(HDTaiQuan billAtShop)
        {
            dalBillAtShop.Add(billAtShop);
        }

        public bool Delete(int id)
        {
            HDTaiQuan bill = GetByID(id);
            if (bill != null)
            {
                dalBillAtShop.Delete(bill);
                return true;
            }
            return false;
        }

        public void ExportBillAtShopToWord(HDTaiQuan bill, List<CTHDTaiQuan> billDetails, int totalPrice, string templatePath, string exportPath)
        {
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();

            dictionaryData.Add("Ma", bill.Ma.ToString());
            dictionaryData.Add("Ban", bill.Ban.Ten);
            dictionaryData.Add("KhachHang", bill.KhachHang.Ten);
            dictionaryData.Add("NhanVien", bill.NhanVien.Ten);
            dictionaryData.Add("ThoiGianVao", bill.ThoiGianVao.ToString().Trim());
            dictionaryData.Add("ThoiGianRa", bill.ThoiGianRa.ToString().Trim());
            dictionaryData.Add("TongTienTruocGG", Tools.ConvertToCurrency(totalPrice));
            dictionaryData.Add("GiamGia", bill.GiamGia);
            dictionaryData.Add("TongTien", Tools.ConvertToCurrency(bill.TongTien));

            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateBillAtShopTemplate(exportPath, dictionaryData, billDetails);
        }

        public void ExportBillTakeAwayToWord(HDTaiQuan bill, List<CTHDTaiQuan> billDetails, int totalPrice, string templatePath, string exportPath)
        {
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();

            dictionaryData.Add("Ma", bill.Ma.ToString());
            dictionaryData.Add("KhachHang", bill.KhachHang.Ten);
            dictionaryData.Add("NhanVien", bill.NhanVien.Ten);
            dictionaryData.Add("ThoiGianVao", bill.ThoiGianVao.ToString().Trim());
            dictionaryData.Add("ThoiGianRa", bill.ThoiGianRa.ToString().Trim());
            dictionaryData.Add("TongTienTruocGG", Tools.ConvertToCurrency(totalPrice));
            dictionaryData.Add("GiamGia", bill.GiamGia);
            dictionaryData.Add("TongTien", Tools.ConvertToCurrency(bill.TongTien));

            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateBillAtShopTemplate(exportPath, dictionaryData, billDetails);
        }

        public List<HDTaiQuan> GetAll()
        {
            return dalBillAtShop.GetAll();
        }

        public HDTaiQuan GetBillAtShopByTableID(int tableID)
        {
            return GetBillUnPaied().SingleOrDefault(x => x.MaBan == tableID);
        }

        public List<HDTaiQuan> GetBillTakeAwayUnPaid()
        {
            return GetBillUnPaied().Where(x => x.MaBan == null).ToList();
        }

        public List<HDTaiQuan> GetBillUnPaied()
        {
            return GetAll().Where(x => x.TongTien == 0 && x.ThoiGianRa == null).ToList();
        }

        public HDTaiQuan GetByID(int id)
        {
            return dalBillAtShop.GetByID(id);
        }

        public int GetNewID()
        {
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public void SwapTable(int oldTableID, int newTableID)
        {
            HDTaiQuan b = GetBillAtShopByTableID(oldTableID);
            b.MaBan = newTableID;
            Update(b);
        }

        public bool Update(HDTaiQuan billAtShop)
        {
            if (GetByID(billAtShop.Ma) != null)
            {
                dalBillAtShop.Update(billAtShop);
                return true;
            }
            return false;
        }
    }
}