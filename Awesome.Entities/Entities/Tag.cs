﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Awesome.Entities
{
	public class Tag : BaseEntity
	{
		[Key]
		public int TagId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Post> Posts { get; set; }
	}
}
