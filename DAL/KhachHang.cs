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
    using System.Collections.Generic;

    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.HDGiaoHangs = new HashSet<HDGiaoHang>();
            this.HDTaiQuans = new HashSet<HDTaiQuan>();
        }

        public int Ma { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HDGiaoHang> HDGiaoHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HDTaiQuan> HDTaiQuans { get; set; }
    }
}
