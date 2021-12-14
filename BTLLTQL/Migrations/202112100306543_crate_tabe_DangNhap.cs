namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crate_tabe_DangNhap : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DangNhaps", "RoleID");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.DangNhaps", "RoleID", c => c.String());
        }
    }
}
