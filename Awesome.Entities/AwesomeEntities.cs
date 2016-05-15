using Awesome.Entities.Entities;
using Awesome.Entities.Mappings;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Awesome.Entities
{
	public class AwesomeEntities : IdentityDbContext<ApplicationUser>
	{
		public AwesomeEntities(string nameOrConnectionString) :
			base(nameOrConnectionString)
		{
			//Database.SetInitializer<AwesomeEntities>(new DropCreateDatabaseAlwaysInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ApplicationUserMapping());

			modelBuilder.Configurations.Add(new CommentMapping());

			modelBuilder.Configurations.Add(new CommentNodeMapping());

			modelBuilder.Configurations.Add(new PostMapping());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Post> Posts { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Tag> Tags { get; set; }

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