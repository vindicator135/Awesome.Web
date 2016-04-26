using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities.Mappings
{
	class CommentNodeMapping : EntityTypeConfiguration<CommentNode>
	{
		internal CommentNodeMapping()
		{
			ToTable(typeof(CommentNode).Name);

			HasKey(x => new { x.AncestorId, x.OffspringId });
		}
	}
}
