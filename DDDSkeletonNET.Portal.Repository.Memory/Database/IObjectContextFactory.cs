using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
	public interface IObjectContextFactory
	{
		InMemoryDatabaseObjectContext Create();
	}
}
