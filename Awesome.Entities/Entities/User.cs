using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
	public class User
	{
		public Guid UserId { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public virtual UserProfile UserProfile { get; set; }
	}
}
