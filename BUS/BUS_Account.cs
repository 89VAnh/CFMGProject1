using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Account
    {
        private DAL_Account dalAccount = new DAL_Account();

        public static TaiKhoan currentAccount = null;

        private List<TaiKhoan> accounts = new List<TaiKhoan>();

        public List<TaiKhoan> GetAccounts()
        {
            return dalAccount.GetAccounts();
        }

        public TaiKhoan GetAccountByUn(string un)
        {
            return GetAccounts().SingleOrDefault(a => a.TenDangNhap == un);
        }

        public TaiKhoan GetAccount(string un, string pw)
        {
            accounts = GetAccounts();
            return accounts.SingleOrDefault(a => a.TenDangNhap == un && a.MatKhau == pw);
        }

        public List<TaiKhoan> SearchAccountByUn(string un)
        {
            return GetAccounts().Where(x => x.TenDangNhap.ToLower().Contains(un)).ToList();
        }

        public List<TaiKhoan> SearchAccountsByPositionID(string positionId)
        {
            return GetAccounts().Where(x => x.MaQuyen == positionId).ToList();
        }

        public bool Add(TaiKhoan account)
        {
            if (GetAccounts().SingleOrDefault(x => x.TenDangNhap == account.TenDangNhap) == null)
            {
                dalAccount.Add(account);
                return true;
            }
            else return false;
        }

        public bool Update(TaiKhoan account)
        {
            if (GetAccounts().SingleOrDefault(x => x.TenDangNhap == account.TenDangNhap) != null)
            {
                dalAccount.Update(account);
                return true;
            }
            else return false;
        }

        public bool Delete(string un)
        {
            TaiKhoan account = GetAccounts().SingleOrDefault(x => x.TenDangNhap == un);
            if (account != null)
            {
                dalAccount.Delete(account);
                return true;
            }
            else return false;
        }
    }
}