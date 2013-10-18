using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Portal.Domain.Customer;

namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
	public class DatabaseCustomer
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string Address { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Telephone { get; set; }

	}
}
