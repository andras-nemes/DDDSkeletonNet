using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DDDSkeletonNET.Portal.ApplicationServices.ViewModels;
using DDDSkeletonNET.Portal.Domain.Customer;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers
{
	public class GetCustomersResponse : ServiceResponseBase
	{
		public IEnumerable<CustomerViewModel> Customers { get; set; }
	}
}
