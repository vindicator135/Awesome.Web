using Awesome.Entities;
using Awesome.Entities.Enumerations;
using Awesome.Web.Api.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Awesome.Web.Api.Services
{
	public class TransactionService : BaseService, ITransactionService
	{
		public TransactionService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public async Task CompleteBookSale(Dictionary<string, string> ipn)
		{
			using (var context = this.Context)
			{
				// Only process the transaction if it has not been recorded yet.
				//	Paypal sends the same transaction details 4x if it doesn't receive a 'VERIFICATION' message
				var payPalTransactionId = ipn["txn_id"];
				if (!context.Transactions.Any(t => t.PayPalTransactionId == payPalTransactionId))
				{
					var user = context.Users.FirstOrDefault(x => x.UserName.Equals("Stephen Cate", StringComparison.InvariantCultureIgnoreCase));

					// Step 1 - Add a customer record
					var customer = new Customer
					{
						FirstName = ipn.ContainsKey("first_name") ? HttpUtility.UrlDecode(ipn["first_name"]): string.Empty,
						LastName = ipn.ContainsKey("last_name") ? HttpUtility.UrlDecode(ipn["last_name"]) : string.Empty,
						Email = ipn.ContainsKey("payer_email") ? HttpUtility.UrlDecode(ipn["payer_email"]) : string.Empty,
						Country = ipn.ContainsKey("residence_country") ? ipn["residence_country"] : string.Empty,
						Created = DateTime.UtcNow,
						CreatedBy = user
					};

					context.Customers.Add(customer);

					// Step 2 - Record the transaction details
					DateTime paymentDate;
					HttpUtility.UrlDecode(ipn["payment_date"]).TryParsePaypalDatetimeToUtc(out paymentDate);

					var transaction = new PaypalTransaction
					{
						PaymentDate = paymentDate,
						PaymentStatus = ipn.ContainsKey("payment_status") ? ipn["payment_status"] : string.Empty,
						Amount = Convert.ToDecimal(ipn["payment_gross"].ToString()),
						ItemName = ipn.ContainsKey("item_name") ? HttpUtility.UrlDecode(ipn["item_name"]) : string.Empty,
						ItemNumber = ipn.ContainsKey("item_number") ? ipn["item_number"] : string.Empty,
						PaymentType = ipn.ContainsKey("payment_type") ? ipn["payment_type"] : string.Empty,
						PayPalTransactionId = payPalTransactionId,
						PayPalTransactionType = ipn.ContainsKey("txn_type") ? ipn["txn_type"] : string.Empty,
						PaymentFee = Convert.ToDecimal(ipn["payment_fee"]),
						PaymentCurrency = ipn.ContainsKey("mc_currency") ? ipn["mc_currency"] : string.Empty,
						ReceiptNumber = ipn.ContainsKey("receipt_id") ? ipn["receipt_id"] : string.Empty,
						IpnTrackId = ipn.ContainsKey("ipn_track_id") ? ipn["ipn_track_id"] : string.Empty,
						CustomerId = customer.CustomerId,
						Created = DateTime.UtcNow,
						CreatedBy = user
					};

					context.Transactions.Add(transaction);

					// Step 3 - Create the CustomerRequest while sending the Purchase information to SendInBlue
					try
					{
						var customerRequest = new CustomerRequest
						{
							CustomerId = customer.CustomerId,
							RequestedAt = DateTime.UtcNow,
							RequestType = RequestType.MakingTheBigMoveFullBook,
						};

						var sendInBlue = new SendInBlue(ConfigurationManager.AppSettings["SendInBlue.ApiKey"].ToString());
						var fullName = $"{customer.FirstName ?? string.Empty} {customer.LastName ?? string.Empty}";
						var apiResult = sendInBlue.AddUserToAwesomeWebList(fullName, customer.Email, (int)SendInBlueList.MTBMBookPurchasers);

						customerRequest.ApiCode = apiResult.code;

						customerRequest.ApiMessage = apiResult.message;

						if (apiResult?.code == "success")
						{
							customerRequest.ApiStatus = $"Successfully added to the Purchasers list (ID: {(int)SendInBlueList.MTBMBookPurchasers})";
						}
						else
						{
							customerRequest.ApiStatus = $"There were problems adding the user to the Purchasers list (ID: {(int)SendInBlueList.MTBMBookPurchasers})";
						}

						context.CustomerRequest.Add(customerRequest);
					}
					catch (Exception e)
					{
						_logger.Error(e, "There was an error calling SendInBlue to add the Customer to the list");
					}

					

					await context.SaveChangesAsync();
				}
			}
		}
	}
}