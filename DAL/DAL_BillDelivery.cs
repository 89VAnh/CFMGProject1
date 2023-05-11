using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_BillDelivery
    {
        private QLCPEntities db = new QLCPEntities();

        public List<HDGiaoHang> GetAll()
        {
            return db.HDGiaoHangs.ToList();
        }

        public HDGiaoHang GetByID(int id)
        {
            return db.HDGiaoHangs.Find(id);
        }

        public void Add(HDGiaoHang billDelivery)
        {
            db.HDGiaoHangs.Add(billDelivery);
            db.SaveChanges();
        }

        public void Update(HDGiaoHang billDelivery)
        {
            HDGiaoHang b = db.HDGiaoHangs.Find(billDelivery.Ma);
            b.GiamGia = billDelivery.GiamGia;
            b.TongTien = billDelivery.TongTien;
            b.MaKH = billDelivery.MaKH;
            b.DiaChi = billDelivery.DiaChi;
            b.ThoiGianNhan = billDelivery.ThoiGianNhan;
            db.SaveChanges();
        }

        public void Delete(HDGiaoHang billDelivery)
        {
            db.HDGiaoHangs.Remove(billDelivery);
            db.SaveChanges();
        }
    }
}