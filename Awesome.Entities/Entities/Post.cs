using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class Post : BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PostId { get; set; }

		public string SubContent { get; set; }

		public string SubTitle { get; set; }

		public string PreContent { get; set; }

		public string PostAvatarUrl { get; set; }

		public string Title { get; set; }

		public string TitleText { get; set; }

		public string Content { get; set; }

		public virtual ICollection<Rating> Ratings { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }

		public virtual ICollection<Tag> Tags { get; set; }
	}
}