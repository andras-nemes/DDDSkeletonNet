﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging.EnhancedCustomers
{
	public class InsertCountrySpecificCustomerRequest : ServiceRequestBase
	{
		public CountrySpecificCustomerViewModel CountrySpecificCustomer { get; set; }
	}
}
