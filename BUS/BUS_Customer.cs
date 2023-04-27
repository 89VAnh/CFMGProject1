using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Customer
    {
        private DAL_Customer dalCustomer = new DAL_Customer();

        public List<KhachHang> GetCustomers()
        {
            return dalCustomer.GetCustomers();
        }

        public int GetNewID()
        {
            return GetCustomers().Count() == 0 ? 1 : GetCustomers().Last().Ma + 1;
        }

        public void Add(KhachHang customer)
        {
            dalCustomer.Add(customer);
        }

        public void Update(KhachHang customer)
        {
            dalCustomer.Update(customer);
        }

        public void Delete(KhachHang customer)
        {
            dalCustomer.Delete(customer);
        }
    }
}
