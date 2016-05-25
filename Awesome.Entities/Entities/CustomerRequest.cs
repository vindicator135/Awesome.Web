using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class CustomerRequest
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RequestId { get; set; }
		public string Email { get; set; }
		public int BookId { get; set; }
	}
}