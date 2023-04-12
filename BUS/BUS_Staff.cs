using DAL;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_Staff
    {
        private DAL_Staff dalStaff = new DAL_Staff();

        public NhanVien GetStaffByID(string id)
        {
            return dalStaff.GetStaffByID(id);
        }

        public List<NhanVien> GetStaffs()
        {
            return dalStaff.GetStaffs();
        }

        public void Add(NhanVien staff)
        {
            dalStaff.Add(staff);
        }

        public void Update(NhanVien s)
        {
            dalStaff.Update(s);
        }

        public void Delete(NhanVien staff)
        {
            dalStaff.Delete(staff);
        }
    }
}
