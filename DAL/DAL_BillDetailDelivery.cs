using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_BillDetailDelivery
    {
        private QLCPEntities db = new QLCPEntities();

        public void Add(CTHDGiaoHang billDetail)
        {
            billDetail.SanPham = db.SanPhams.Find(billDetail.MaSP);
            db.CTHDGiaoHangs.Add(billDetail);
            db.SaveChanges();
        }

        public void Delete(CTHDGiaoHang billDetail)
        {
            db.CTHDGiaoHangs.Remove(billDetail);
            db.SaveChanges();
        }

        public List<CTHDGiaoHang> GetAll()
        {
            return db.CTHDGiaoHangs.ToList();
        }

        public CTHDGiaoHang GetByID(int id)
        {
            return db.CTHDGiaoHangs.Find(id);
        }

        public void Update(CTHDGiaoHang billDetail)
        {
            CTHDGiaoHang bd = db.CTHDGiaoHangs.Find(billDetail.Ma);
            bd.MaHD = billDetail.MaHD;
            bd.MaSP = billDetail.MaSP;
            bd.SoLuong = billDetail.SoLuong;
            bd.GhiChu = billDetail.GhiChu;
            db.SaveChanges();
        }
    }
}