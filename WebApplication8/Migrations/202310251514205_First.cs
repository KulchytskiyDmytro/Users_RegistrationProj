namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Byte(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                        RegionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.RegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RegionId", "dbo.Regions");
            DropIndex("dbo.Users", new[] { "RegionId" });
            DropTable("dbo.Users");
            DropTable("dbo.Regions");
        }
    }
}
