using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DDDSkeletonNET.Portal.Repository.Memory.Database;

namespace DDDSkeletonNET.Portal.Repository.Memory.DataContextFactoryOrm
{
	public class HttpAwareOrmDataContextFactory : IObjectContextFactory
	{
		private string _dataContextKey = "Data context";

		public InMemoryDatabaseObjectContext Create()
		{
			InMemoryDatabaseObjectContext objectContext = null;
			if (HttpContext.Current.Items.Contains(_dataContextKey))
			{
				objectContext = HttpContext.Current.Items[_dataContextKey] as InMemoryDatabaseObjectContext;
			}
			else
			{
				objectContext = new InMemoryDatabaseObjectContext();
				Store(objectContext);
			}
			return objectContext;
		}

		private void Store(InMemoryDatabaseObjectContext objectContext)
		{
			if (HttpContext.Current.Items.Contains(_dataContextKey))
			{
				HttpContext.Current.Items[_dataContextKey] = objectContext;
			}
			else
			{
				HttpContext.Current.Items.Add(_dataContextKey, objectContext);
			}
		}
	}
}
