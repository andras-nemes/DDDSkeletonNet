using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging.EnhancedCustomers;

namespace DDDSkeletonNET.Portal.ApplicationServices.Interfaces
{
	public interface ICountrySpecificCustomerService
	{
		InsertCountrySpecificCustomerResponse InsertCountrySpecificCustomer(InsertCountrySpecificCustomerRequest insertCustomerRequest);
	}
}
