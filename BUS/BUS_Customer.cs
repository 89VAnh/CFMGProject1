using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Customer
    {
        private DAL_Customer dalCustomer = new DAL_Customer();

        private List<KhachHang> customerList = new List<KhachHang>();

        public List<KhachHang> GetCustomers()
        {
            return dalCustomer.GetCustomers();
        }

        public int GetNewID()
        {
            if (dalCustomer.GetCustomers().Count == 0) return 1;
            else return customerList.Last().Ma + 1;
        }

        public void Add(KhachHang customer)
        {
            customer.Ma = GetNewID();
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
