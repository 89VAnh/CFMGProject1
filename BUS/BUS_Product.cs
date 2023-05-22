using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Product
    {
        private DAL_Product dalProduct = new DAL_Product();

        public void Add(SanPham product)
        {
            product.Ma = GetNewID();
            dalProduct.Add(product);
        }

        public bool Delete(int productID)
        {
            SanPham product = GetByID(productID);
            if (product != null)
            {
                dalProduct.Delete(product);
                return true;
            }
            return false;
        }

        public List<SanPham> GetAll()
        {
            return dalProduct.GetAll();
        }

        public SanPham GetByID(int id)
        {
            return dalProduct.GetByID(id);
        }

        public int GetNewID()
        {
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public string GetProductName(int id)
        {
            return GetByID(id).Ten;
        }

        public List<SanPham> SearchProductsByCategory(int categoryID)
        {
            return GetAll().Where(x => x.MaDM == categoryID).ToList();
        }

        public List<SanPham> SearchProductsByName(string keyword)
        {
            return GetAll().Where(x => x.Ten.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public bool Update(SanPham product)
        {
            if (GetByID(product.Ma) != null)
            {
                dalProduct.Update(product);
                return true;
            }
            return false;
        }
    }
}