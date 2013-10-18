using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.ApplicationServices.Exceptions
{
	public class ResourceNotFoundException : Exception
	{
		public ResourceNotFoundException(string message)
			: base(message)
		{}

		public ResourceNotFoundException()
			: base("The requested resource was not found.")
		{}
	}
}
