using Awesome.Entities;
using Awesome.Web.Api.Common;
using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class MarketingService : BaseService, IMarketingService
	{
		public MarketingService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public async Task<int> NewExcerptRequest(ExcerptRequest request)
		{
			using (var context = this.Context)
			{
				var newCustomerRequest = new CustomerRequest { BookId = request.BookId, Email = request.Email, Name = request.Name, RequestedAt = DateTime.UtcNow };
				

				var accessId = ConfigurationManager.AppSettings["SendInBlue.ApiKey"].ToString();
				var subscribersListId = ConfigurationManager.AppSettings["SendInBlue.SubscriberListId"].ToString();
				var sendInBlue = new SendInBlue(accessId);

				var attributesDictionary = new Dictionary<string, string>();
				attributesDictionary.Add("NAME", request.Name);

				//var attributesDictionary = new List<object> { new { NAME = request.Name } };

				var newUser = new
				{
					email = request.Email,
					attributes = attributesDictionary,
					listid = new int[] { 2 },
				};

				dynamic apiResult = sendInBlue.create_update_user(newUser);

				newCustomerRequest.ApiCode = apiResult.code;
				newCustomerRequest.ApiMessage = apiResult.message;

				if (apiResult?.code == "success")
				{
					newCustomerRequest.ApiStatus = $"Successfully added to the Subscribers list (ID: {subscribersListId})";
				}
				else
				{
					newCustomerRequest.ApiStatus = $"There were problems adding the user to the Subscribers list (ID: {subscribersListId})";
				}

				context.CustomerRequest.Add(newCustomerRequest);

				return await context.SaveChangesAsync();
			}

			
		}

		public async Task<int> ProcessExcerptRequest(ExcerptRequest request)
		{
			throw new NotImplementedException();
		}
	}
}