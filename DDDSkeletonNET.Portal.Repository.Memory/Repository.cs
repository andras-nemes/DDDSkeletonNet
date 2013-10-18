using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.Repository.Memory.Database;

namespace DDDSkeletonNET.Portal.Repository.Memory
{
	public abstract class Repository<DomainType, IdType, DatabaseType> : IUnitOfWorkRepository where DomainType : IAggregateRoot
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IObjectContextFactory _objectContextFactory;

		public Repository(IUnitOfWork unitOfWork, IObjectContextFactory objectContextFactory)
		{
			if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
			if (objectContextFactory == null) throw new ArgumentNullException("Object context factory");
			_unitOfWork = unitOfWork;
			_objectContextFactory = objectContextFactory;
		}

		public IObjectContextFactory ObjectContextFactory
		{
			get
			{
				return _objectContextFactory;
			}
		}

		public void Update(DomainType aggregate)
		{
			_unitOfWork.RegisterUpdate(aggregate, this);
		}

		public void Insert(DomainType aggregate)
		{
			_unitOfWork.RegisterInsertion(aggregate, this);
		}

		public void Delete(DomainType aggregate)
		{
			_unitOfWork.RegisterDeletion(aggregate, this);
		}

		public abstract DomainType FindBy(IdType id);

		public abstract DatabaseType ConvertToDatabaseType(DomainType domainType);

		public void PersistInsertion(IAggregateRoot aggregateRoot)
		{
			DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
			_objectContextFactory.Create().AddEntity<DatabaseType>(databaseType);
		}

		public void PersistUpdate(IAggregateRoot aggregateRoot)
		{
			DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
			_objectContextFactory.Create().UpdateEntity<DatabaseType>(databaseType);
		}

		public void PersistDeletion(IAggregateRoot aggregateRoot)
		{
			DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
			_objectContextFactory.Create().DeleteEntity<DatabaseType>(databaseType);
		}

		private DatabaseType RetrieveDatabaseTypeFrom(IAggregateRoot aggregateRoot)
		{
			DomainType domainType = (DomainType)aggregateRoot;
			DatabaseType databaseType = ConvertToDatabaseType(domainType);
			return databaseType;
		}
	}
}
