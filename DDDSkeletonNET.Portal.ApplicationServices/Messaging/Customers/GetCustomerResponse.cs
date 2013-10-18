using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Portal.ApplicationServices.ViewModels;
using DDDSkeletonNET.Portal.Domain.Customer;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers
{
	public class GetCustomerResponse : ServiceResponseBase
	{
		public CustomerViewModel Customer { get; set; }
	}
}
