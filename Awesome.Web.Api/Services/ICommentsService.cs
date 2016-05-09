﻿using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface ICommentsService
	{

		Task<List<CommentItem>> GetComments(Guid postId, int numberOfMaxRecords);
	}
}
