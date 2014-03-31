using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Portal.Domain.ValueObjects
{
	public abstract class Country : ValueObjectBase
	{
		public abstract string CountryCode { get; }
		public abstract string CountryName { get; }

		protected override void Validate()
		{
			if (string.IsNullOrEmpty(CountryCode)) AddBrokenRule(ValueObjectBusinessRule.CountryCodeRequired);
			if (string.IsNullOrEmpty(CountryName)) AddBrokenRule(ValueObjectBusinessRule.CountryNameRequired);
		}
	}
}
