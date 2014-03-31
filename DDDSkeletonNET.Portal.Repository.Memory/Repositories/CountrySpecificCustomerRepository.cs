using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.Domain.Customer;
using DDDSkeletonNET.Portal.Repository.Memory.Database;

namespace DDDSkeletonNET.Portal.Repository.Memory.Repositories
{
	public class CountrySpecificCustomerRepository : Repository<CountrySpecificCustomer, int, DatabaseCountrySpecificCustomer>
		, ICountrySpecificCustomerRepository
	{
		public CountrySpecificCustomerRepository(IUnitOfWork unitOfWork, IObjectContextFactory objectContextFactory)
			: base(unitOfWork, objectContextFactory)
		{}

		public override CountrySpecificCustomer FindBy(int id)
		{
			return null;
		}

		public override DatabaseCountrySpecificCustomer ConvertToDatabaseType(CountrySpecificCustomer domainType)
		{
			return null;
		}

		public IEnumerable<CountrySpecificCustomer> FindAll()
		{
			return null;
		}
	}
}
