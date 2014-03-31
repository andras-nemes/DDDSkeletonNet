using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.Domain.ValueObjects
{
	public class Germany : Country
	{
		public override string CountryCode
		{
			get { return CountryCodes.Germany; }
		}

		public override string CountryName
		{
			get { return "Germany"; }
		}
	}
}
