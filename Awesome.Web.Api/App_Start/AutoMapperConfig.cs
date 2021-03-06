﻿using AutoMapper;
using Awesome.Entities;
using Awesome.Entities.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api
{
	public static class AutoMapperConfig
	{
		public static void Configure()
		{
			Mapper.CreateMap<Post, PostItem>();
			//Mapper.CreateMap<DiscussionItem, Discussion>();

			Mapper.CreateMap<Comment, CommentItem>();
			//Mapper.CreateMap<CommentItem, Comment>();

			Mapper.CreateMap<Tag, TagItem>();
			//Mapper.CreateMap<TagItem, Tag>();

			Mapper.CreateMap<ApplicationUser, UserItem>();
			//Mapper.CreateMap<UserItem, User>();
		}
	}
}