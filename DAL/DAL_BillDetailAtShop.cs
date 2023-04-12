using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_BillDetailAtShop
    {
        private QLCPEntities db = new QLCPEntities();

        public List<CTHDTaiQuan> GetBillDetailAtShopes()
        {
            return db.CTHDTaiQuans.ToList();
        }

        public int GetNewID()
        {
            if (db.CTHDTaiQuans.Count() == 0) return 1;
            else return db.CTHDTaiQuans.ToList().Last().Ma + 1;
        }

        public void Add(CTHDTaiQuan billDetail)
        {
            billDetail.SanPham = db.SanPhams.Find(billDetail.MaSP);
            db.CTHDTaiQuans.Add(billDetail);
            db.SaveChanges();
        }

        public void Update(CTHDTaiQuan billDetail)
        {
            CTHDTaiQuan bd = db.CTHDTaiQuans.Find(billDetail.Ma);
            bd.MaHD = billDetail.MaHD;
            bd.MaSP = billDetail.MaSP;
            bd.SoLuong = billDetail.SoLuong;
            bd.GhiChu = billDetail.GhiChu;
            db.SaveChanges();
        }

        public void Delete(CTHDTaiQuan billDetail)
        {
            db.CTHDTaiQuans.Remove(billDetail);
            db.SaveChanges();
        }
    }
}
