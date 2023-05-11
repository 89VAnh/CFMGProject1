using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_BillDetailAtShop
    {
        private QLCPEntities db = new QLCPEntities();

        public List<CTHDTaiQuan> GetAll()
        {
            return db.CTHDTaiQuans.ToList();
        }

        public CTHDTaiQuan GetByID(int id)
        {
            return db.CTHDTaiQuans.Find(id);
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