using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Product
    {
        private QLCPEntities db = new QLCPEntities();

        public void Add(SanPham product)
        {
            db.SanPhams.Add(product);
            db.SaveChanges();
        }

        public void Delete(SanPham product)
        {
            db.SanPhams.Remove(product);
            db.SaveChanges();
        }

        public List<SanPham> GetAll()
        {
            return db.SanPhams.ToList();
        }

        public SanPham GetByID(int id)
        {
            return db.SanPhams.Find(id);
        }

        public void Update(SanPham product)
        {
            SanPham p = db.SanPhams.Find(product.Ma);
            p.Ten = product.Ten;
            p.MaDM = product.MaDM;
            p.DonGia = product.DonGia;
            db.SaveChanges();
        }
    }
}