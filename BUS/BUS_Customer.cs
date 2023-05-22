using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Customer
    {
        private DAL_Customer dalCustomer = new DAL_Customer();

        public void Add(KhachHang customer)
        {
            customer.Ma = GetNewID();
            dalCustomer.Add(customer);
        }

        public bool Delete(string customerID)
        {
            KhachHang customer = GetByID(customerID);
            if (customer != null)
            {
                dalCustomer.Delete(customer);
                return true;
            }
            return false;
        }

        public List<KhachHang> GetAll()
        {
            return dalCustomer.GetAll();
        }

        public KhachHang GetByID(string id)
        {
            return dalCustomer.GetByID(id);
        }

        public string GetNewID()
        {
            int id = GetAll().Count() == 0 ? 1 : Int32.Parse(GetAll().Last().Ma.Substring(2)) + 1;
            return "KH" + id;
        }

        public List<KhachHang> SearchCustomerByName(string keyword)
        {
            return GetAll().Where(x => x.Ten.ToLower().Contains(keyword)).ToList();
        }

        public bool Update(KhachHang customer)
        {
            if (GetByID(customer.Ma) != null)
            {
                dalCustomer.Update(customer);
                return true;
            }
            return false;
        }
    }
}