namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creae_table_role : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropColumn("dbo.DangNhaps", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}
