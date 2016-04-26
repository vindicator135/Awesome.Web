using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
	public class UserProfile
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid UserProfileId { get; set; }

		public string AvatarUrl { get; set; }
	}
}
