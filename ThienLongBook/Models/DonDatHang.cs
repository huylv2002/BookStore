//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThienLongBook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            this.ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }
    
        public int soDH { get; set; }
        public string maKH { get; set; }
        public Nullable<System.DateTime> ngayDH { get; set; }
        public Nullable<decimal> triGia { get; set; }
        public Nullable<bool> daGiao { get; set; }
        public Nullable<System.DateTime> ngayGiaoHang { get; set; }
        public string tenNguoiNhan { get; set; }
        public string diaChiNhan { get; set; }
        public string dienThoaiNhan { get; set; }
        public Nullable<bool> hTThanhtoan { get; set; }
        public Nullable<bool> hTGiaoHang { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }
    }
}
