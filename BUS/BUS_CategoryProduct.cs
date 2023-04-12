using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_CategoryProduct
    {
        private DAL_CategoryProduct dalCategoryProduct = new DAL_CategoryProduct();
        private List<DanhMucSanPham> categoryProducts = new List<DanhMucSanPham>();

        public List<DanhMucSanPham> GetCategoryProducts()
        {
            return dalCategoryProduct.GetCategoryProducts();
        }

        public int GetNewID()
        {
            List<DanhMucSanPham> categoryproducts = GetCategoryProducts();
            if (categoryproducts.Count == 0) return 1;
            else return categoryproducts.Last().Ma + 1;
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
