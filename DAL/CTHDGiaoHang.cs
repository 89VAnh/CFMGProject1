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

    public partial class CTHDGiaoHang
    {
        public int Ma { get; set; }
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }

        public virtual HDGiaoHang HDGiaoHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
