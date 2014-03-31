using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Portal.Domain.Customer;
using DDDSkeletonNET.Portal.Domain.Factories;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.Domain.CountryRules
{
	public class HungarianCustomerRule : CountrySpecificCustomerRule
	{
		public override Country Country
		{
			get { return CountryFactory.Create(CountryCodes.Hungary); }
		}

		public override List<BusinessRule> GetBrokenRules(CountrySpecificCustomer customer)
		{
			List<BusinessRule> brokenRules = new List<BusinessRule>();
			if (string.IsNullOrEmpty(customer.NickName))
			{
				brokenRules.Add(new BusinessRule("Hungarian customers must have a nickname"));
			}
			return brokenRules;
		}
	}
}
