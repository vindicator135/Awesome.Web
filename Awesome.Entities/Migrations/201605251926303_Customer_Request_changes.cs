namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_Request_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerRequests", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerRequests", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerRequests", new[] { "CreatedBy_Id" });
            DropIndex("dbo.CustomerRequests", new[] { "LastUpdatedBy_Id" });
            DropColumn("dbo.CustomerRequests", "Created");
            DropColumn("dbo.CustomerRequests", "LastUpdated");
            DropColumn("dbo.CustomerRequests", "CreatedBy_Id");
            DropColumn("dbo.CustomerRequests", "LastUpdatedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerRequests", "LastUpdatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.CustomerRequests", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.CustomerRequests", "LastUpdated", c => c.DateTime());
            AddColumn("dbo.CustomerRequests", "Created", c => c.DateTime(nullable: false));
            CreateIndex("dbo.CustomerRequests", "LastUpdatedBy_Id");
            CreateIndex("dbo.CustomerRequests", "CreatedBy_Id");
            AddForeignKey("dbo.CustomerRequests", "LastUpdatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CustomerRequests", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
