using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Product
    {
        DAL_Product dalProduct = new DAL_Product();

        public List<SanPham> GetProducts()
        {
            return dalProduct.GetProducts();
        }
        public int GetNewID()
        {
            List<SanPham> products = GetProducts();
            if (products.Count == 0) return 1;
            else return products.Last().Ma + 1;
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
