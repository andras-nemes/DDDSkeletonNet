using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.Domain.Factories
{
	public interface ICountryFactory
	{
		Country CreateCountry(string countryCode);
	}
}
