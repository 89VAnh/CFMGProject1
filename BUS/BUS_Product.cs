using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Product
    {
        private DAL_Product dalProduct = new DAL_Product();

        public List<SanPham> GetProducts()
        {
            return dalProduct.GetProducts();
        }

        public int GetNewID()
        {
            return GetProducts().Count() == 0 ? 1 : GetProducts().Last().Ma + 1;
        }

        public void Add(SanPham product)
        {
            dalProduct.Add(product);
        }

        public void Update(SanPham product)
        {
            dalProduct.Update(product);
        }

        public void Delete(SanPham product)
        {
            dalProduct.Delete(product);
        }
    }
}
