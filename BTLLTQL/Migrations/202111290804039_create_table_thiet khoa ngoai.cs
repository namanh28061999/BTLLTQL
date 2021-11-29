namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_thietkhoangoai : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoaDonBanHangs", "MaHang", c => c.String(maxLength: 128));
            CreateIndex("dbo.HoaDonBanHangs", "MaHang");
            AddForeignKey("dbo.HoaDonBanHangs", "MaHang", "dbo.HangBans", "MaHang");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDonBanHangs", "MaHang", "dbo.HangBans");
            DropIndex("dbo.HoaDonBanHangs", new[] { "MaHang" });
            AlterColumn("dbo.HoaDonBanHangs", "MaHang", c => c.String());
        }
    }
}
