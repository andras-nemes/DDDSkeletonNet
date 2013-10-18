using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers
{
	public class InsertCustomerRequest : ServiceRequestBase
	{
		public CustomerPropertiesViewModel CustomerProperties { get; set; }
	}
}
