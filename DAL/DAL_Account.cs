using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Account
    {
        private QLCPEntities db = new QLCPEntities();

        public List<TaiKhoan> GetAccounts()
        {
            return db.TaiKhoans.ToList();
        }

        public void Add(TaiKhoan account)
        {
            db.TaiKhoans.Add(account);
            db.SaveChanges();
        }

        public void Update(TaiKhoan account)
        {
            TaiKhoan a = db.TaiKhoans.Find(account.TenDangNhap);
            a.MatKhau = account.MatKhau;
            a.Email = account.Email;
            a.MaQuyen = account.MaQuyen;
            db.SaveChanges();
        }

        public void Delete(TaiKhoan account)
        {
            db.TaiKhoans.Remove(account);
            db.SaveChanges();
        }
    }
}
