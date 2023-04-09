using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_BillAtShop
    {
        QLCPEntities db = new QLCPEntities();

        public List<HDTaiQuan> GetBillAtShops()
        {
            return db.HDTaiQuans.ToList();
        }

        public HDTaiQuan GetBillAtShopByTableID(int tableID)
        {
            return db.HDTaiQuans
                .SingleOrDefault(x => x.MaBan == tableID && x.ThoiGianRa == null);
        }
        public void Add(HDTaiQuan billAtShop)
        {
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
