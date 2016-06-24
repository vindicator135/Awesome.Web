using Awesome.Entities;
using Awesome.Entities.Enumerations;
using Awesome.Web.Api.Common;
using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
				var user = context.Users.FirstOrDefault(x => x.UserName.Equals(request.RequestedBy, StringComparison.InvariantCultureIgnoreCase));

				// Step 1 - Create the Customer record
				var customer = new Customer { PreferredName = request.Name, Email = request.Email, Created = DateTime.UtcNow, CreatedBy = user };

				context.Customers.Add(customer);

				// Step 2 - Create the Customer Request
				var newCustomerRequest = new CustomerRequest
				{ 
					CustomerId = customer.CustomerId,
					RequestType = RequestType.MakingTheBigMoveExcerpt,
					RequestedAt = DateTime.UtcNow
				};
				
				var sendInBlue = new SendInBlue(ConfigurationManager.AppSettings["SendInBlue.ApiKey"].ToString());

				var apiResult = sendInBlue.AddUserToAwesomeWebList(customer.PreferredName, customer.Email, (int)SendInBlueList.MTBMBlogSubscribers);

				newCustomerRequest.ApiCode = apiResult.code;

				newCustomerRequest.ApiMessage = apiResult.message;

				if (apiResult?.code == "success")
				{
					newCustomerRequest.ApiStatus = $"Successfully added to the Subscribers list (ID: {(int)SendInBlueList.MTBMBlogSubscribers})";
				}
				else
				{
					newCustomerRequest.ApiStatus = $"There were problems adding the user to the Subscribers list (ID: {(int)SendInBlueList.MTBMBlogSubscribers})";
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