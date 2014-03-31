using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Portal.Domain.Customer;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.Domain.CountryRules
{
	public abstract class CountrySpecificCustomerRule
	{
		public abstract Country Country { get; }
		public abstract List<BusinessRule> GetBrokenRules(CountrySpecificCustomer customer);
	}
}
