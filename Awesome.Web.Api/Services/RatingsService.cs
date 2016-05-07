using Awesome.Entities;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class RatingsService : BaseService, IRatingsService
	{
		public RatingsService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public async Task<double> GetPostAvarageRating(Guid postId)
		{
			var rating = 0.0;

			var post = factory.Create().Posts.Include("Ratings").FirstOrDefault(d => d.PostId == postId);

			if (post != null && post.Ratings != null && post.Ratings.Count() > 0)
			{
				rating = post.Ratings.Average(x => x.Score);
			}
			return rating;
		}
	}
}