using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DDDSkeletonNET.Portal.ApplicationServices.ViewModels
{
	[DataContract]
	public class CustomerViewModel
	{
		[DataMember(Name="Customer name")]
		public string Name { get; set; }
		[DataMember(Name="Address")]
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		[DataMember(Name="City")]
		public string City { get; set; }
		[DataMember(Name="Postal code")]
		public string PostalCode { get; set; }
		[DataMember(Name="Customer id")]
		public int Id { get; set; }
	}
}
