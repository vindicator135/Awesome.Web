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
	public class UserMapping : EntityTypeConfiguration<User>
	{
		public UserMapping()
		{
			HasOptional(d => d.UserProfile).WithOptionalDependent().Map(m => m.MapKey("UserProfileId"));
		}
	}
}
