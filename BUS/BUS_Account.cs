using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Account
    {
        public static TaiKhoan currentAccount = null;
        private List<TaiKhoan> accounts = new List<TaiKhoan>();
        private DAL_Account dalAccount = new DAL_Account();

        public bool Add(TaiKhoan account)
        {
            if (GetAll().SingleOrDefault(x => x.TenDangNhap == account.TenDangNhap) == null)
            {
                dalAccount.Add(account);
                return true;
            }
            else return false;
        }

        public bool Delete(string un)
        {
            TaiKhoan account = GetAll().SingleOrDefault(x => x.TenDangNhap == un);
            if (account != null)
            {
                dalAccount.Delete(account);
                return true;
            }
            else return false;
        }

        public TaiKhoan GetAccount(string un, string pw)
        {
            return GetAll().SingleOrDefault(a => a.TenDangNhap == un && a.MatKhau == pw);
        }

        public TaiKhoan GetAccountByUn(string un)
        {
            return GetAll().SingleOrDefault(a => a.TenDangNhap == un);
        }

        public List<TaiKhoan> GetAll()
        {
            return dalAccount.GetAll();
        }

        public List<TaiKhoan> SearchAccountByUn(string un)
        {
            return GetAll().Where(x => x.TenDangNhap.ToLower().Contains(un)).ToList();
        }

        public List<TaiKhoan> SearchAccountsByPositionID(string positionId)
        {
            return GetAll().Where(x => x.MaQuyen == positionId).ToList();
        }

        public bool Update(TaiKhoan account)
        {
            if (GetAll().SingleOrDefault(x => x.TenDangNhap == account.TenDangNhap) != null)
            {
                dalAccount.Update(account);
                return true;
            }
            else return false;
        }
    }
}