﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities.Mappings
{
	public class PostMapping : EntityTypeConfiguration<Post>
	{
		public PostMapping()
		{
			HasMany(p => p.Comments)
				.WithRequired(c => c.Post)
				.HasForeignKey(c => c.PostId)
				.WillCascadeOnDelete(true);

			HasMany(d => d.Tags)
				.WithMany(t => t.Posts)
				.Map(dt => {
					dt.MapLeftKey("PostId");
					dt.MapRightKey("TagId");
					dt.ToTable("PostTags");
				});

		}
	}
}
