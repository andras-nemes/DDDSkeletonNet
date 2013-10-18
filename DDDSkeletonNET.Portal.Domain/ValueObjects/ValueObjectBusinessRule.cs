using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Portal.Domain.ValueObjects
{
	public static class ValueObjectBusinessRule
	{
		public static readonly BusinessRule CityInAddressRequired = new BusinessRule("An address must have a city.");
	}
}
