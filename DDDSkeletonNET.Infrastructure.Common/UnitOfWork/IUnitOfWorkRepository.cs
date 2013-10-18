using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Infrastructure.Common.UnitOfWork
{
	public interface IUnitOfWorkRepository
	{
		void PersistInsertion(IAggregateRoot aggregateRoot);
		void PersistUpdate(IAggregateRoot aggregateRoot);
		void PersistDeletion(IAggregateRoot aggregateRoot);
	}
}
