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

        public bool CheckUn(string un)
        {
            accounts = GetAccounts();
            return accounts.SingleOrDefault(a => a.TenDangNhap == un) != null;
        }

        public TaiKhoan GetAccount(string un, string pw)
        {
            accounts = GetAccounts();
            return accounts.SingleOrDefault(a => a.TenDangNhap == un && a.MatKhau == pw);
        }

        public void Add(TaiKhoan account)
        {
            dalAccount.Add(account);
        }

        public void Update(TaiKhoan account)
        {
            dalAccount.Update(account);
        }

        public void Delete(TaiKhoan account)
        {
            dalAccount.Delete(account);
        }
    }
}
