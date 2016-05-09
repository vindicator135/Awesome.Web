using Awesome.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
	public class Rating
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid RatingId { get; set; }

		public int Score { get; set; }

		public virtual ApplicationUser CreatedBy { get; set; }
	}
}
