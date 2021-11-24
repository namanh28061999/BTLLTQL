namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_5_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangNhaps",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
            CreateTable(
                "dbo.HangBans",
                c => new
                    {
                        MaHang = c.String(nullable: false, maxLength: 128),
                        TenHang = c.String(),
                        ViTri = c.String(),
                        SoLuong = c.String(),
                        DonGia = c.String(),
                        ThanhTien = c.String(),
                        HanSD = c.String(),
                    })
                .PrimaryKey(t => t.MaHang);
            
            CreateTable(
                "dbo.HoaDonBanHangs",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 128),
                        NgayBan = c.String(),
                        MaHang = c.String(),
                        SoLuong = c.String(),
                        DonGia = c.String(),
                        ThanhTien = c.String(),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.NCCs",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 128),
                        TenNCC = c.String(),
                        TenHang = c.String(),
                        Diachi = c.String(),
                        SoDienThoai = c.String(),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.NVBanHangs",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        TenNV = c.String(),
                        DCNV = c.String(),
                        SoDienThoai = c.String(),
                    })
                .PrimaryKey(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NVBanHangs");
            DropTable("dbo.NCCs");
            DropTable("dbo.HoaDonBanHangs");
            DropTable("dbo.HangBans");
            DropTable("dbo.DangNhaps");
        }
    }
}
