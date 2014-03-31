using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.Domain.ValueObjects
{
	public class Hungary : Country
	{
		public override string CountryCode
		{
			get { return CountryCodes.Hungary; }
		}

		public override string CountryName
		{
			get { return "Hungary"; }
		}
	}
}
