using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class PaypalTransaction : BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TransactionId { get; set; }
		
		public DateTime PaymentDate { get; set; }
		public string PaymentStatus { get; set; }
		public string PaymentType { get; set; }
		public string PayPalTransactionId { get; set; }
		public string PayPalTransactionType { get; set; }
		public string ItemName { get; set; }
		public string ItemNumber { get; set; }
		public decimal Amount { get; set; }

		public int CustomerId { get; set; }
		public virtual Customer Customer{ get; set; }
		public decimal PaymentFee { get; set; }
		public string PaymentCurrency { get; set; }
		public string ReceiptNumber { get; set; }
		public string IpnTrackId { get; set; }
	}
}