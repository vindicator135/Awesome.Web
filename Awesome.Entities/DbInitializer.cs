using Awesome.Entities.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Awesome.Entities
{
	public class DropCreateDatabaseAlwaysInitializer : DropCreateDatabaseAlways<AwesomeEntities>
	{
		protected override void Seed(AwesomeEntities context)
		{
			Seeder.Seed(context);
		}
	}

	internal static class Seeder
	{
		public static void Seed(AwesomeEntities context)
		{

			var user = new ApplicationUser { UserName = "vindicator135@gmail.com", Email = "vindicator135@gmail.com" };

			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

			var userResult = userManager.CreateAsync(user, "unknown_1").Result;

			context.SaveChanges();

			var tag1 = new Tag { TagId = 1, Created = DateTime.Now, Description = "United States of America", Name = "US" };
			context.Tags.Add(tag1);

			var tag2 = new Tag { TagId = 2, Created = DateTime.Now, Description = "Canada", Name = "CA" };
			context.Tags.Add(tag2);

			var tag3 = new Tag { TagId = 3, CreatedBy = user, Created = DateTime.Now, Description = "Australia", Name = "AU" };

			context.Tags.Add(tag3);

			var post = new Post
			{

				Comments = new List<Comment> { new Comment { Content = "Yeah, why not?", Created = DateTime.Now, CreatedBy = user } },
				Content = "Why the big move?",
				Created = DateTime.Now,
				CreatedBy = user,
				Tags = new List<Tag> { tag1, tag2, tag3 }
			};

			context.Posts.Add(post);

			context.SaveChanges();
		}
	}
}