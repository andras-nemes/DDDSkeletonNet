using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.Domain.Customer
{
	public class Customer : EntityBase<int>, IAggregateRoot
	{
		public string Name { get; set; }
		public Address CustomerAddress { get; set; }

		protected override void Validate()
		{
			if (string.IsNullOrEmpty(Name))
			{
				AddBrokenRule(CustomerBusinessRule.CustomerNameRequired);
			}
			CustomerAddress.ThrowExceptionIfInvalid();
		}
	}
}
