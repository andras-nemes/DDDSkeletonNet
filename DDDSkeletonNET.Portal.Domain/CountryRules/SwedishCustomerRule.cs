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
	public class SwedishCustomerRule : CountrySpecificCustomerRule
	{
		public override Country Country
		{
			get { return CountryFactory.Create(CountryCodes.Sweden); }
		}

		public override List<BusinessRule> GetBrokenRules(CountrySpecificCustomer customer)
		{
			List<BusinessRule> brokenRules = new List<BusinessRule>();
			if (customer.Age < 18)
			{
				brokenRules.Add(new BusinessRule("Swedish customers must be at least 18."));
			}
			return brokenRules;
		}
	}
}
