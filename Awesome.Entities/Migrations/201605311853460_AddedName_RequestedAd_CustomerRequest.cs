namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedName_RequestedAd_CustomerRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerRequests", "Name", c => c.String());
            AddColumn("dbo.CustomerRequests", "RequestedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerRequests", "RequestedAt");
            DropColumn("dbo.CustomerRequests", "Name");
        }
    }
}
