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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThienLongBookEntities : DbContext
    {
        public ThienLongBookEntities()
            : base("name=ThienLongBookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<ChiTietDatHang> ChiTietDatHangs { get; set; }
        public virtual DbSet<ChiTietThamDo> ChiTietThamDoes { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<ThamDo> ThamDoes { get; set; }
        public virtual DbSet<VietSach> VietSaches { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
    }
}
