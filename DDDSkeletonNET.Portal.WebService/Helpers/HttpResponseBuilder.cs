using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging;

namespace DDDSkeletonNET.Portal
{
	/// <summary>
	/// Extension methods for HttpResponse
	/// </summary>
	public static class HttpResponseBuilder
	{

		/// <summary>
		/// Build a HttpResponseMessage based on the HttpRequest message and the operation response that 
		/// an Application service provided
		/// </summary>
		/// <param name="requestMessage">The HttpRequestMessage that came with the HTTP request to the web API</param>
		/// <param name="baseResponse">The populated response that an Application Service, e.g. ICustomerService generated</param>
		/// <returns>A HttpResponseMessage that can be sent to the requesting client</returns>
		public static HttpResponseMessage BuildResponse(this HttpRequestMessage requestMessage, ServiceResponseBase baseResponse)
		{
			HttpStatusCode statusCode = HttpStatusCode.OK;
			if (baseResponse.Exception != null)
			{
				statusCode = baseResponse.Exception.ConvertToHttpStatusCode();
				HttpResponseMessage message = new HttpResponseMessage(statusCode);
				message.Content = new StringContent(baseResponse.Exception.Message);
				throw new HttpResponseException(message);
			}
			return requestMessage.CreateResponse<ServiceResponseBase>(statusCode, baseResponse);
		}
	}
}