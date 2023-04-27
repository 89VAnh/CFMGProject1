using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_CategoryProduct
    {
        private DAL_CategoryProduct dalCategoryProduct = new DAL_CategoryProduct();

        public List<DanhMucSanPham> GetCategoryProducts()
        {
            return dalCategoryProduct.GetCategoryProducts();
        }

        public int GetNewID()
        {
            return GetCategoryProducts().Count() == 0 ? 1 : GetCategoryProducts().Last().Ma + 1;
        }

        public void Add(DanhMucSanPham categoryProduct)
        {
            dalCategoryProduct.Add(categoryProduct);
        }

        public void Update(DanhMucSanPham categoryProduct)
        {
            dalCategoryProduct.Update(categoryProduct);
        }

        public void Delete(DanhMucSanPham categoryProduct)
        {
            dalCategoryProduct.Delete(categoryProduct);
        }
    }
}
