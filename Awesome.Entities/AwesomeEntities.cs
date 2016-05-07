using Awesome.Entities.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
    public class AwesomeEntities : DbContext
    {
		public AwesomeEntities(string nameOrConnectionString) : 
			base(nameOrConnectionString)
		{
			// Database.SetInitializer<AwesomeEntities>(new DropCreateDatabaseAlwaysInitializer());

			//this.Discussions.Count();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new CommentMapping());
			
			modelBuilder.Configurations.Add(new CommentNodeMapping());

			modelBuilder.Configurations.Add(new UserMapping());

			modelBuilder.Configurations.Add(new DiscussionTagMapping());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Post> Posts { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Tag> Tags { get; set;}

		public DbSet<User> Users { get; set; }

		public DbSet<UserProfile> UserProfiles { get; set; }

		public DbSet<Rating> Ratings { get; set; }

		public DbSet<TEntity> Get<TEntity>() where TEntity : class
		{
			var t = this;

			var props = t.GetType().GetProperties();

			foreach (var p in props)
				if (p.PropertyType == typeof(DbSet<TEntity>))
					return (p.GetMethod.Invoke(this, null) as DbSet<TEntity>);

			return null;
		}
	}
}
