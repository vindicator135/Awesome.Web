using Awesome.Entities.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class CustomerRequest
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RequestId { get; set; }

		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		public RequestType RequestType { get; set; }
		public string ApiStatus { get; set; }
		public string ApiCode { get; set; }
		public string ApiMessage { get; set; }
		public DateTime? RequestedAt { get; set; }
	}
}