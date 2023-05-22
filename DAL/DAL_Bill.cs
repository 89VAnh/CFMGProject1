using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Bill
    {
        private QLCPEntities db = new QLCPEntities();

        public List<HDTaiQuan> GetBillAtShopUnPaied(DateTime startDate, DateTime endDate)
        {
            return db.HDTaiQuans.Where(x => x.MaBan != null &&
            DateTime.Compare((DateTime)x.ThoiGianRa, startDate) != -1 && DateTime.Compare((DateTime)x.ThoiGianRa, endDate) != 1).ToList();
        }

        public List<HDGiaoHang> GetBillDeliveryUnPaied(DateTime startDate, DateTime endDate)
        {
            return db.HDGiaoHangs.Where(x => DateTime.Compare((DateTime)x.ThoiGianNhan, startDate) != -1 && DateTime.Compare((DateTime)x.ThoiGianNhan, endDate) != 1).ToList();
        }

        public List<HDTaiQuan> GetBillTakeAwayUnPaied(DateTime startDate, DateTime endDate)
        {
            return db.HDTaiQuans.Where(x => x.MaBan == null && DateTime.Compare((DateTime)x.ThoiGianRa, startDate) != -1 && DateTime.Compare((DateTime)x.ThoiGianRa, endDate) != 1).ToList();
        }

        public List<DoanhThuTheoLoaiHD_Result> RevenueByBillType(DateTime startDate, DateTime endDate)
        {
            return db.DoanhThuTheoLoaiHD(startDate.Date, endDate.Date).ToList();
        }

        public List<DoanhThuTheoNgay_Result> RevenueByDate(DateTime startDate, DateTime endDate)
        {
            return db.DoanhThuTheoNgay(startDate, endDate).ToList();
        }

        public List<TopDoanhThuSP_Result> TopProduct(DateTime startDate, DateTime endDate)
        {
            return db.TopDoanhThuSP(startDate.Date, endDate.Date).ToList();
        }
    }
}