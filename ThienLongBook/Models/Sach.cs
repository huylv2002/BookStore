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
    
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.VietSaches = new HashSet<VietSach>();
            this.ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }
    
        public int maSach { get; set; }
        public string tenSach { get; set; }
        public string donViTinh { get; set; }
        public Nullable<decimal> donGia { get; set; }
        public string moTa { get; set; }
        public string hinhMinhHoa { get; set; }
        public string maCD { get; set; }
        public string maNXB { get; set; }
        public Nullable<System.DateTime> ngayCapNHat { get; set; }
        public Nullable<int> soLuongBan { get; set; }
        public Nullable<int> soLanXem { get; set; }
        public string trangThai { get; set; }
    
        public virtual ChuDe ChuDe { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VietSach> VietSaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }
    }
}
