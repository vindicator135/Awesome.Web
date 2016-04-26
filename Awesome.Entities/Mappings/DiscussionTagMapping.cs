using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities.Mappings
{
	public class DiscussionTagMapping : EntityTypeConfiguration<Discussion>
	{
		public DiscussionTagMapping()
		{
			HasMany(d => d.Tags)
				.WithMany(t => t.Discussions)
				.Map(dt => {
					dt.MapLeftKey("DiscussionId");
					dt.MapRightKey("TagId");
					dt.ToTable("DiscussionTags");
				});
		}
	}
}
