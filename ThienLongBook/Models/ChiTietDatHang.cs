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
    
    public partial class ChiTietDatHang
    {
        public int soDH { get; set; }
        public int maSach { get; set; }
        public Nullable<int> soLuong { get; set; }
        public Nullable<decimal> giaBan { get; set; }
        public Nullable<decimal> thanhTien { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
    }
}
