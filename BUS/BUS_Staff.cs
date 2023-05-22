using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BUS_Staff
    {
        private DAL_Staff dalStaff = new DAL_Staff();

        public bool Add(NhanVien staff)
        {
            staff.Ma = GetNewID(staff.MaQuyen);
            dalStaff.Add(staff);
            return true;
        }

        public bool Delete(string id)
        {
            NhanVien nhanVien = GetByID(id);
            if (nhanVien != null)
            {
                dalStaff.Delete(nhanVien);
                return true;
            }
            else return false;
        }

        public List<NhanVien> GetAll()
        {
            return dalStaff.GetAll();
        }

        public NhanVien GetByID(string id)
        {
            return dalStaff.GetByID(id);
        }

        public string GetNewID(string position)
        {
            int id = GetAll().Count() == 0 ? 1 : Int32.Parse(GetAll().Where(x => x.Ma.Contains(position)).Last().Ma.Substring(2)) + 1;
            return position + id;
        }

        public List<NhanVien> SearchStaffsByName(string keyword)
        {
            return GetAll().Where(x => x.Ten.ToLower().Contains(keyword)).ToList();
        }

        public List<NhanVien> SearchStaffsByPosition(string id)
        {
            return GetAll()
                    .Where(x => x.MaQuyen == id).ToList();
        }

        public bool Update(NhanVien staff)
        {
            if (GetByID(staff.Ma) != null)
            {
                dalStaff.Update(staff);
                return true;
            }
            else return false;
        }
    }
}