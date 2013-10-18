using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers
{
	public class DeleteCustomerRequest : IntegerIdRequest
	{
		public DeleteCustomerRequest(int customerId) : base(customerId)
		{}
	}
}
