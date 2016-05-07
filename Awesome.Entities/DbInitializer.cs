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
			
			var userId = new Guid("2C42BA71-183B-43EA-8A56-06CD16433F0C");

			context.Users.Add(new User { UserId = userId, UserName = "Stephen", Password = "unknown_1" });

			var tagId1 = new Guid("EEA069E8-38D6-E511-8325-54271E914DCC");

			var tag1 = new Tag { TagId = tagId1, CreatedBy = userId, Created = DateTime.Now, Description = "United States of America", Name = "US" };
			context.Tags.Add(tag1);

			var tagId2 = new Guid("EFA069E8-38D6-E511-8325-54271E914DCC");
			var tag2 = new Tag { TagId = tagId2, CreatedBy = userId, Created = DateTime.Now, Description = "Canada", Name = "CA" };
			context.Tags.Add(tag2);

			var tagId3 = new Guid("F0A069E8-38D6-E511-8325-54271E914DCC"); 
			var tag3 = new Tag { TagId = tagId3, CreatedBy = userId, Created = DateTime.Now, Description = "Australia", Name = "AU" };

			context.Tags.Add(tag3);

			var discussion1 = new Post
			{

				Comments = new List<Comment> { new Comment { Content = "Yeah, why not?", Created = DateTime.Now, CreatedBy = userId } },
				Content = "Why the big move?",
				Created = DateTime.Now,
				CreatedBy = userId,
				Tags = new List<Tag> { tag1, tag2, tag3 }
			};

			context.Posts.Add(discussion1);

			context.SaveChanges();
		}
	}
}