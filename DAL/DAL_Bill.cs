using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Bill
    {
        private QLCPEntities db = new QLCPEntities();

        public List<DoanhThuTheoNgay_Result> GetRevenueByDate()
        {
            return db.DoanhThuTheoNgay().ToList();
        }

        public List<DoanhThuTheoThang_Result> GetRevenueByMonth()
        {
            return db.DoanhThuTheoThang().ToList();
        }

        public List<DoanhThuTheoNam_Result> GetRevenueByYear()
        {
            return db.DoanhThuTheoNam().ToList();
        }
    }
}