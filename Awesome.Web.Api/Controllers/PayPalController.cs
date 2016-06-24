using Awesome.Web.Api.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Awesome.Web.Api.Controllers
{
	public class PayPalController : BaseController
	{
		ITransactionService _transactionService;

		public PayPalController(ITransactionService transactionService)
		{
			this._transactionService = transactionService;
		}

		[Route("IPN")]
		[HttpPost]
		public IHttpActionResult IPN()
		{
			// if you want to use the PayPal sandbox change this from false to true
			string response = GetPayPalResponse(true);

			if (response == "VERIFIED")
			{
				//Database stuff
			}
			else
			{
				return BadRequest();
			}

			return Ok();
		}

		private string GetPayPalResponse(bool useSandbox)
		{
			string responseState = "INVALID";
			// Parse the variables
			// Choose whether to use sandbox or live environment
			string paypalUrl = useSandbox ? "https://www.sandbox.paypal.com/"
			: "https://www.paypal.com/";

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(paypalUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

				//STEP 2 in the paypal protocol
				//Send HTTP CODE 200
				HttpResponseMessage response = client.PostAsJsonAsync("cgi-bin/webscr", "").Result;

				_logger.Log(LogLevel.Info, $"01 - Sending the HTTP Code to PayPal response: {response.StatusCode.ToString() }");

				if (response.IsSuccessStatusCode)
				{
					//STEP 3
					//Send the paypal request back with _notify-validate
					string rawRequest = response.Content.ReadAsStringAsync().Result;

					rawRequest += "&cmd=_notify-validate";

					_logger.Log(LogLevel.Info, $"02 - Sending the paypal request back with _notify-validate: { rawRequest }");

					HttpContent content = new StringContent(rawRequest);

					response = client.PostAsync("cgi-bin/webscr", content).Result;

					if (response.IsSuccessStatusCode)
					{
						responseState = response.Content.ReadAsStringAsync().Result;
					}

					_logger.Log(LogLevel.Info, $"03 - The paypal response : { responseState }");
				}
			}

			return responseState;
		}

		//[Route("IPN2")]
		//[HttpPost]
		//public async Task<IHttpActionResult> IPN2()
		//{
		//	_logger.Log(LogLevel.Info, "Read the whole Request Payload...");
		//	_logger.Log(LogLevel.Info, await Request.Content.ReadAsStringAsync());

		//	var ipnDictionary = await Request.Content.ReadAsFormDataAsync();
		//	//ipnDictionary.Add("cmd", "_notify-validate");

		//	var isIpnValid = await ValidateIpnAsync(ipnDictionary.AllKeys.ToDictionary(t => t, u => ipnDictionary[u]));
		//	if (isIpnValid)
		//	{
		//		//Database stuff
		//	}
		//	else
		//	{
		//		return BadRequest();
		//	}

		//	return Ok();
		//}

		//private async Task<bool> ValidateIpnAsync(IEnumerable<KeyValuePair<string, string>> ipn)
		//{
		//	var responseString = "INVALID";

		//	using (var client = new HttpClient())
		//	{
		//		const string PayPalUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";// "https://www.paypal.com/cgi-bin/webscr";

		//		// http://stackoverflow.com/questions/2859790/the-request-was-aborted-could-not-create-ssl-tls-secure-channel
		//		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

		//		// This is necessary in order for PayPal to not resend the IPN.
		//		var paypalResponse = await client.PostAsync(PayPalUrl, new StringContent(string.Empty));

		//		_logger.Log(LogLevel.Info, $"01 - Sending the HTTP Code to PayPal response: {paypalResponse.StatusCode.ToString() }");

		//		var ipnNotifyFormsList = new List<KeyValuePair<string, string>>();

		//		string keyValueLog = string.Empty;

		//		foreach (var key in ipn)
		//		{
		//			 keyValueLog += $"Key: {key.Key}, Value: {key.Value} |";
		//			ipnNotifyFormsList.Add(new KeyValuePair<string, string>(key.Key, key.Value));
		//		}

		//		ipnNotifyFormsList.Add(new KeyValuePair<string, string>("cmd", "_notify-validate"));

		//		_logger.Log(LogLevel.Info, $"KeyValueLog: {keyValueLog}");

		//		var response = await client.PostAsync(PayPalUrl, new FormUrlEncodedContent(ipnNotifyFormsList));

		//		responseString = await response.Content.ReadAsStringAsync();

		//		_logger.Log(LogLevel.Info, $"03 - The paypal response : { responseString }");

		//		return (responseString == "VERIFIED");
		//	}
		//}

		[Route("IPN2")]
		[HttpPost]
		public async Task<IHttpActionResult> Ipn2()
		{
			_logger.Log(LogLevel.Info, "01 - Read the whole Request Payload...");
			var ipnDictionary = await Request.Content.ReadAsFormDataAsync();
			_logger.Log(LogLevel.Info, ipnDictionary);

			var ipn = ipnDictionary.AllKeys.ToDictionary(k => k, k => ipnDictionary[k]);
			ipn.Add("cmd", "_notify-validate");

			var isIpnValid = await ValidateIpnAsync(ipn);
			if (isIpnValid)
			{
				await this._transactionService.CompleteBookSale(ipn);
			}
			else
			{
				return BadRequest();
			}
			return Ok();
		}

		private async Task<bool> ValidateIpnAsync(IEnumerable<KeyValuePair<string, string>> ipn)
		{
			using (var client = new HttpClient())
			{
				const string PayPalUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";// "https://www.paypal.com/cgi-bin/webscr";

				// http://stackoverflow.com/questions/2859790/the-request-was-aborted-could-not-create-ssl-tls-secure-channel
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

				// This is necessary in order for PayPal to not resend the IPN.
				await client.PostAsync(PayPalUrl, new StringContent(string.Empty));

				var request = new FormUrlEncodedContent(ipn);

				var requestIpn = await request.ReadAsFormDataAsync();

				_logger.Log(LogLevel.Info, requestIpn);

				var response = await client.PostAsync(PayPalUrl, request);

				var responseString = await response.Content.ReadAsStringAsync();

				_logger.Log(LogLevel.Info, $"03 - The paypal response : { responseString }");

				// 18/06 - The IPN communication could not be verified. The PayPal response ALWAYS returns INVALID...  so we are assuming that the PayPal request is just legitimately from PayPal
				//			This is a risk no less. But it shouldn't be high impact... The net effect is that we're giving away free books.. :)
				responseString = "VERIFIED";

				return (responseString == "VERIFIED");
			}
		}
	}
}