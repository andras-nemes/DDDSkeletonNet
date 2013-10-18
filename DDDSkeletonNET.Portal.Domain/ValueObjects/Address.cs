using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Portal.Domain.ValueObjects
{
	public class Address : ValueObjectBase
	{
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }

		protected override void Validate()
		{
			if (string.IsNullOrEmpty(City))
			{
				AddBrokenRule(ValueObjectBusinessRule.CityInAddressRequired);
			}
		}
	}
}
