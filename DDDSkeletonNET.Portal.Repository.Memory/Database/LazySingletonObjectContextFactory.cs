using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
	public class LazySingletonObjectContextFactory : IObjectContextFactory
	{
		public InMemoryDatabaseObjectContext Create()
		{
			return InMemoryDatabaseObjectContext.Instance;
		}
	}
}
