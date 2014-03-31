using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DDDSkeletonNET.Portal.ApplicationServices.Interfaces;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging.EnhancedCustomers;

namespace DDDSkeletonNET.Portal.WebService.Controllers
{
    public class CountrySpecificCustomersController : ApiController
    {
		private readonly ICountrySpecificCustomerService _countrySpecificCustomerService;

		public CountrySpecificCustomersController(ICountrySpecificCustomerService countrySpecificCustomerService)
		{
			if (countrySpecificCustomerService == null) throw new ArgumentNullException("CountrySpecificCustomerService");
			_countrySpecificCustomerService = countrySpecificCustomerService;
		}

		public HttpResponseMessage Post(CountrySpecificCustomerViewModel viewModel)
		{
			ServiceResponseBase response = _countrySpecificCustomerService.InsertCountrySpecificCustomer(new InsertCountrySpecificCustomerRequest() { CountrySpecificCustomer = viewModel });
			return Request.BuildResponse(response);
		}
    }
}
