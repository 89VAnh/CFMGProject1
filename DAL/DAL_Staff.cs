﻿using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Staff
    {
        private QLCPEntities db = new QLCPEntities();

        public void Add(NhanVien staff)
        {
            db.NhanViens.Add(staff);
            db.SaveChanges();
        }

        public void Delete(NhanVien staff)
        {
            db.NhanViens.Remove(staff);
            db.SaveChanges();
        }

        public List<NhanVien> GetAll()
        {
            return db.NhanViens.ToList();
        }

        public NhanVien GetByID(string id)
        {
            return db.NhanViens.Find(id);
        }

        public void Update(NhanVien staff)
        {
            NhanVien s = db.NhanViens.SingleOrDefault(x => x.Ma == staff.Ma);
            s.Ten = staff.Ten;
            s.GioiTinh = staff.GioiTinh;
            s.SDT = staff.SDT;
            s.Email = staff.Email;
            s.DiaChi = staff.DiaChi;
            s.MaQuyen = staff.MaQuyen;
            db.SaveChanges();
        }
    }
}