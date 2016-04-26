using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface IRatingsService
	{
		Task<double> GetDiscussionAvarageRating(Guid discussionId);
	}
}
