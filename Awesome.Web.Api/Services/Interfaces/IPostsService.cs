﻿using Awesome.Web.Api.Models;
using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface IPostsService
	{
		Task<List<PostItem>> SearchPosts(PostSearchRequest request);

		Task<object> AddPost(PostUpdateRequest request);

		Task<object> RemovePost(int postId);

		Task<object> EditPost(PostUpdateRequest request);

		Task<PostItem> GetPostDetails(int postId);
	}
}
