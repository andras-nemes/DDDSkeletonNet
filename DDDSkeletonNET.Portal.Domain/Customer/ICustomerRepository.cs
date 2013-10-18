using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Portal.Domain.Customer
{
	public interface ICustomerRepository : IRepository<Customer, int>
	{
	}
}
