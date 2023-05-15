﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public partial class QLCPEntities : DbContext
    {
        System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public QLCPEntities()
            : base("name=QLCPEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<CTHDGiaoHang> CTHDGiaoHangs { get; set; }
        public virtual DbSet<CTHDTaiQuan> CTHDTaiQuans { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<HDGiaoHang> HDGiaoHangs { get; set; }
        public virtual DbSet<HDTaiQuan> HDTaiQuans { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<VW_DoanhThu> VW_DoanhThu { get; set; }
        public virtual DbSet<VW_SoLuongSP> VW_SoLuongSP { get; set; }

        public virtual ObjectResult<DoanhThuTheoLoaiHD_Result> DoanhThuTheoLoaiHD(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));

            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DoanhThuTheoLoaiHD_Result>("DoanhThuTheoLoaiHD", startDateParameter, endDateParameter);
        }

        public virtual ObjectResult<DoanhThuTheoNgay_Result> DoanhThuTheoNgay(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));

            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DoanhThuTheoNgay_Result>("DoanhThuTheoNgay", startDateParameter, endDateParameter);
        }

        public virtual ObjectResult<TopDoanhThuSP_Result> TopDoanhThuSP(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));

            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TopDoanhThuSP_Result>("TopDoanhThuSP", startDateParameter, endDateParameter);
        }
    }
}
