using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Awesome.Web;

namespace Awesome.Web
{
	public class DiscussionHub : Hub
	{
		public void addDiscussion(DiscussionViewModel discussion)
		{
			Clients.All.updateRecentDiscussions(discussion);
		}
	}
}