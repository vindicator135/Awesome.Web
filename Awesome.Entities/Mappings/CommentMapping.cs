using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Awesome.Entities.Mappings
{
	/// <summary>
	/// Comments are self-referencing entities based on -
	///		http://stackoverflow.com/questions/11565423/most-efficient-method-of-self-referencing-tree-using-entity-framework
	/// </summary>
	public class CommentMapping : EntityTypeConfiguration<Comment>
	{
		public CommentMapping()
		{
			HasOptional(d => d.Parent)
				.WithMany(p => p.Children)
				.Map(c => c.MapKey("ParentId"))
				.WillCascadeOnDelete(false);

			// has many ancestors
			HasMany(p => p.Ancestors)
				.WithRequired(d => d.Offspring)
				.HasForeignKey(d => d.OffspringId)
				.WillCascadeOnDelete(false);

			// has many offspring
			HasMany(p => p.Offsprings)
				.WithRequired(d => d.Ancestor)
				.HasForeignKey(d => d.AncestorId)
				.WillCascadeOnDelete(false);
		}
	}
}
