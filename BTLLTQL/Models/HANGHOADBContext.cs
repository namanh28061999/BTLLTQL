using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTLLTQL.Models
{
    public partial class HANGHOADBContext : DbContext
    {
        public HANGHOADBContext()
            : base("name=HANGHOADBContext")
        {
        }
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<HangBan> HangBans { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanhangs { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<NVBanHang> NVBanHangs { get; set; }      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
