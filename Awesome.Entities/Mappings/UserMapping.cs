using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Awesome.Entities.Entities;

namespace Awesome.Entities.Mappings
{
	/// <summary>
	/// Comments are self-referencing entities based on -
	///		http://stackoverflow.com/questions/11565423/most-efficient-method-of-self-referencing-tree-using-entity-framework
	/// </summary>
	public class ApplicationUserMapping : EntityTypeConfiguration<ApplicationUser>
	{
		public ApplicationUserMapping()
		{
			ToTable("Users");
		}
	}
}
