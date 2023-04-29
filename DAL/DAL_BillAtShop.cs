using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_BillAtShop
    {
        private QLCPEntities db = new QLCPEntities();

        public List<HDTaiQuan> GetBillAtShopes()
        {
            return db.HDTaiQuans.ToList();
        }

        public void Add(HDTaiQuan billAtShop)
        {
            billAtShop.Ban = db.Bans.Find(billAtShop.MaBan);
            db.HDTaiQuans.Add(billAtShop);
            db.SaveChanges();
        }

        public void Update(HDTaiQuan billAtShop)
        {
            HDTaiQuan b = db.HDTaiQuans.Find(billAtShop.Ma);
            b.MaBan = billAtShop.MaBan;
            b.GiamGia = billAtShop.GiamGia;
            b.TongTien = billAtShop.TongTien;
            b.MaNV = billAtShop.MaNV;
            b.MaKH = billAtShop.MaKH;
            b.ThoiGianVao = billAtShop.ThoiGianVao;
            b.ThoiGianRa = billAtShop.ThoiGianRa;
            db.SaveChanges();
        }

        public void Delete(HDTaiQuan billAtShop)
        {
            db.HDTaiQuans.Remove(billAtShop);
            db.SaveChanges();
        }
    }
}
