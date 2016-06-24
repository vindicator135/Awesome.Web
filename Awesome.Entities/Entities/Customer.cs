using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class Customer : BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId { get; set; }
		public string Email { get; set; }
		public string PreferredName { get; set; }
		public string Website { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
	}
}