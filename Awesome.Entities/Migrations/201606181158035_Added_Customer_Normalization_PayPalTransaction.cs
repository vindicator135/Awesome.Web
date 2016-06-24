namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Customer_Normalization_PayPalTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PreferredName = c.String(),
                        Website = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        LastUpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            CreateTable(
                "dbo.PaypalTransactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentStatus = c.String(),
                        PaymentType = c.String(),
                        PayPalTransactionId = c.String(),
                        PayPalTransactionType = c.String(),
                        ItemName = c.String(),
                        ItemNumber = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        LastUpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.LastUpdatedBy_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            AddColumn("dbo.CustomerRequests", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerRequests", "RequestType", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerRequests", "CustomerId");
            AddForeignKey("dbo.CustomerRequests", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.CustomerRequests", "Email");
            DropColumn("dbo.CustomerRequests", "BookId");
            DropColumn("dbo.CustomerRequests", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerRequests", "Name", c => c.String());
            AddColumn("dbo.CustomerRequests", "BookId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerRequests", "Email", c => c.String());
            DropForeignKey("dbo.PaypalTransactions", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaypalTransactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PaypalTransactions", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerRequests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "LastUpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PaypalTransactions", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.PaypalTransactions", new[] { "CreatedBy_Id" });
            DropIndex("dbo.PaypalTransactions", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Customers", new[] { "CreatedBy_Id" });
            DropIndex("dbo.CustomerRequests", new[] { "CustomerId" });
            DropColumn("dbo.CustomerRequests", "RequestType");
            DropColumn("dbo.CustomerRequests", "CustomerId");
            DropTable("dbo.PaypalTransactions");
            DropTable("dbo.Customers");
        }
    }
}
