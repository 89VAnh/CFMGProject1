using DAL;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_Bill
    {
        private DAL_Bill dalBill = new DAL_Bill();

        public List<DoanhThuTheoNgay_Result> GetRevenueByDate()
        {
            return dalBill.GetRevenueByDate();
        }

        public List<DoanhThuTheoThang_Result> GetRevenueByMonth()
        {
            return dalBill.GetRevenueByMonth();
        }

        public List<DoanhThuTheoNam_Result> GetRevenueByYear()
        {
            return dalBill.GetRevenueByYear();
        }
    }
}