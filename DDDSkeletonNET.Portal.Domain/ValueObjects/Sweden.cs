using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.Domain.ValueObjects
{
	public class Sweden : Country
	{
		public override string CountryCode
		{
			get { return CountryCodes.Sweden; }
		}

		public override string CountryName
		{
			get { return "Sweden"; }
		}
	}
}
