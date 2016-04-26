using Awesome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Awesome.Web.Api.Services
{
	public class RatingsService : IRatingsService
	{
		private AwesomeEntities _context;

		public RatingsService(AwesomeEntities context)
		{
			this._context = context;
		}

		public async Task<double> GetDiscussionAvarageRating(Guid discussionId)
		{
			var rating = 0.0;

			var discussion = this._context.Discussions.Include("Ratings").FirstOrDefault(d => d.DiscussionId == discussionId);

			if (discussion != null && discussion.Ratings != null && discussion.Ratings.Count() > 0)
			{
				rating = discussion.Ratings.Average(x => x.Score);

			}
			return rating;
		}
	}
}