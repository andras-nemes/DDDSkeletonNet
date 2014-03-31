using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Portal.Domain.CountryRules;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.Domain.Customer
{
	public class CountrySpecificCustomer : EntityBase<int>, IAggregateRoot
	{
		private Country _country;

		public CountrySpecificCustomer(Country country)
		{
			_country = country;
		}

		public string FirstName { get; set; }
		public int Age { get; set; }
		public string NickName { get; set; }
		public string Email { get; set; }

		protected override void Validate()
		{
			//overall rule
			if (string.IsNullOrEmpty(FirstName))
			{
				AddBrokenRule(new BusinessRule("All customers must have a first name"));
			}
			List<BusinessRule> brokenRules = new List<BusinessRule>();
			brokenRules.AddRange(CountrySpecificCustomerRuleFactory.Create(_country).GetBrokenRules(this));
			foreach (BusinessRule brokenRule in brokenRules)
			{
				AddBrokenRule(brokenRule);
			}
		}
	}
}
