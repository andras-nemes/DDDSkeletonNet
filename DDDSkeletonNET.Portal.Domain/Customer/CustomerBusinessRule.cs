using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Portal.Domain.Customer
{
	public static class CustomerBusinessRule
	{
		public static readonly BusinessRule CustomerNameRequired = new BusinessRule("A customer must have a name.");
	}
}
