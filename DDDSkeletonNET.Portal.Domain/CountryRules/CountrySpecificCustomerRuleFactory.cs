using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.Domain.CountryRules
{
	public class CountrySpecificCustomerRuleFactory
	{
		private static IEnumerable<CountrySpecificCustomerRule> GetAllCountryRules()
		{
			List<CountrySpecificCustomerRule> implementingRules = new List<CountrySpecificCustomerRule>()
			{
				new HungarianCustomerRule()
				, new SwedishCustomerRule()
				, new GermanCustomerRule()
			};
			return implementingRules;
		}

		public static CountrySpecificCustomerRule Create(Country country)
		{
			return (from c in GetAllCountryRules() where c.Country.CountryCode == country.CountryCode select c).FirstOrDefault();
		}
	}
}
