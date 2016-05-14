using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome.Entities
{
	public class Comment : BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid CommentId { get; set; }

		public string Content { get; set; }

		public Post Post { get; set; }

		public string AvatarUrl { get; set; }

		public string UserName { get; set; }

		public Comment Parent { get; set; }

		public ICollection<Comment> Children { get; set; }

		public virtual ICollection<CommentNode> Ancestors { get; set; }

		public virtual ICollection<CommentNode> Offsprings { get; set; }
	}
}