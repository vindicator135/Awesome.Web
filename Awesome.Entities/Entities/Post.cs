using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class Post : BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid PostId { get; set; }

		public string Content { get; set; }

		public virtual ICollection<Rating> Ratings { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }

		public virtual ICollection<Tag> Tags { get; set; }
	}
}