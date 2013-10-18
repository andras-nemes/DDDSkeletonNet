using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeletonNET.Infrastructure.Common.UnitOfWork
{
	public interface IUnitOfWork
	{
		void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository);
		void RegisterInsertion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository);
		void RegisterDeletion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository);
		void Commit();
	}
}
