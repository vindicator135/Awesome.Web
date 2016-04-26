﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome.Web.Api.Models.Request
{
	public class DiscussionSearchRequest
	{
		public Guid DiscussionId { get; set; }
		public int Grouping { get; set; }

		public string Search { get; set; }

		public int MaxResults { get; set; }
	}


}
