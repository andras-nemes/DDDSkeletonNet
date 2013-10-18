using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DDDSkeletonNET.Portal.ApplicationServices.Interfaces;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers;

namespace DDDSkeletonNET.Portal.WebService.Controllers
{
    public class CustomersController : ApiController
    {
		private readonly ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			if (customerService == null) throw new ArgumentNullException("CustomerService in CustomersController");
			_customerService = customerService;
		}

		public HttpResponseMessage Get()
		{
			ServiceResponseBase resp = _customerService.GetAllCustomers();
			return Request.BuildResponse(resp);
		}

		public HttpResponseMessage Get(int id)
		{
			ServiceResponseBase resp = _customerService.GetCustomer(new GetCustomerRequest(id));
			return Request.BuildResponse(resp);
		}

		public HttpResponseMessage Post(CustomerPropertiesViewModel insertCustomerViewModel)
		{
			InsertCustomerResponse insertCustomerResponse = _customerService.InsertCustomer(new InsertCustomerRequest() { CustomerProperties = insertCustomerViewModel });
			return Request.BuildResponse(insertCustomerResponse);
		}

		public HttpResponseMessage Put(UpdateCustomerViewModel updateCustomerViewModel)
		{
			UpdateCustomerRequest req =
				new UpdateCustomerRequest(updateCustomerViewModel.Id)
				{
					CustomerProperties = new CustomerPropertiesViewModel()
					{
						AddressLine1 = updateCustomerViewModel.AddressLine1
						,AddressLine2 = updateCustomerViewModel.AddressLine2
						,City = updateCustomerViewModel.City
						,Name = updateCustomerViewModel.Name
						,PostalCode = updateCustomerViewModel.PostalCode
					}
				};
			UpdateCustomerResponse updateCustomerResponse =	_customerService.UpdateCustomer(req);
			return Request.BuildResponse(updateCustomerResponse);
		}

		public HttpResponseMessage Delete(int id)
		{
			DeleteCustomerResponse deleteCustomerResponse = _customerService.DeleteCustomer(new DeleteCustomerRequest(id));
			return Request.BuildResponse(deleteCustomerResponse);
		}
    }

	public class UpdateCustomerViewModel : CustomerPropertiesViewModel
	{
		public int Id { get; set; }
	}

}
