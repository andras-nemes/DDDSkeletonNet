using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging
{
	public abstract class ServiceResponseBase
	{
		public ServiceResponseBase()
		{
			this.Exception = null;
		}

		/// <summary>
		/// Save the exception thrown so that consumers can read it
		/// </summary>
		public Exception Exception { get; set; }
	}
}
