using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class Book
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BookId { get; set; }

		public string Title { get; set; }

		public string ExcerptSourceUrl { get; set; }
	}
}