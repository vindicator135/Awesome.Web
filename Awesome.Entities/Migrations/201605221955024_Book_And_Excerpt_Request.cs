namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_And_Excerpt_Request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        BookId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        LastUpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerRequests", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerRequests", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerRequests", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.CustomerRequests", new[] { "CreatedBy_Id" });
            DropTable("dbo.CustomerRequests");
        }
    }
}
