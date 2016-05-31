namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_api_status_fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerRequests", "ApiStatus", c => c.String());
            AddColumn("dbo.CustomerRequests", "ApiCode", c => c.String());
            AddColumn("dbo.CustomerRequests", "ApiMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerRequests", "ApiMessage");
            DropColumn("dbo.CustomerRequests", "ApiCode");
            DropColumn("dbo.CustomerRequests", "ApiStatus");
        }
    }
}
