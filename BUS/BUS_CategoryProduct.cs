using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_CategoryProduct
    {
        private DAL_CategoryProduct dalCategoryProduct = new DAL_CategoryProduct();

        public void Add(DanhMucSanPham categoryProduct)
        {
            categoryProduct.Ma = GetNewID();
            dalCategoryProduct.Add(categoryProduct);
        }

        public bool Delete(int categoryProductID)
        {
            DanhMucSanPham categoryProduct = GetByID(categoryProductID);
            if (categoryProduct != null)
            {
                dalCategoryProduct.Delete(categoryProduct);
                return true;
            }
            return false;
        }

        public List<DanhMucSanPham> GetAll()
        {
            return dalCategoryProduct.GetAll();
        }

        public DanhMucSanPham GetByID(int id)
        {
            return dalCategoryProduct.GetByID(id);
        }

        public int GetNewID()
        {
            return GetAll().Count() == 0 ? 1 : GetAll().Last().Ma + 1;
        }

        public List<DanhMucSanPham> SearchCategoryProductsByName(string keyword)
        {
            return GetAll().Where(x => x.Ten.ToLower().Contains(keyword)).ToList();
        }

        public bool Update(DanhMucSanPham categoryProduct)
        {
            if (GetByID(categoryProduct.Ma) != null)
            {
                dalCategoryProduct.Update(categoryProduct);
                return true;
            }
            return false;
        }
    }
}