namespace Awesome.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Transaction_fields_for_more_paypal_information : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaypalTransactions", "PaymentFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PaypalTransactions", "PaymentCurrency", c => c.String());
            AddColumn("dbo.PaypalTransactions", "ReceiptNumber", c => c.String());
            AddColumn("dbo.PaypalTransactions", "IpnTrackId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaypalTransactions", "IpnTrackId");
            DropColumn("dbo.PaypalTransactions", "ReceiptNumber");
            DropColumn("dbo.PaypalTransactions", "PaymentCurrency");
            DropColumn("dbo.PaypalTransactions", "PaymentFee");
        }
    }
}
