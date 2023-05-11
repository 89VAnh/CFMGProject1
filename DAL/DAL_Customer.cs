using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Customer
    {
        private QLCPEntities db = new QLCPEntities();

        public List<KhachHang> GetAll()
        {
            return db.KhachHangs.ToList();
        }

        public KhachHang GetByID(string id)
        {
            return db.KhachHangs.Find(id);
        }

        public void Add(KhachHang customer)
        {
            db.KhachHangs.Add(customer);
            db.SaveChanges();
        }

        public void Update(KhachHang customer)
        {
            KhachHang s = db.KhachHangs.SingleOrDefault(x => x.Ma == customer.Ma);
            s.Ten = customer.Ten;
            s.GioiTinh = customer.GioiTinh;
            s.SDT = customer.SDT;
            s.Email = customer.Email;
            s.DiaChi = customer.DiaChi;
            db.SaveChanges();
        }

        public void Delete(KhachHang customer)
        {
            db.KhachHangs.Remove(customer);
            db.SaveChanges();
        }
    }
}