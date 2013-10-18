using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.Domain.Customer;
using DDDSkeletonNET.Portal.Domain.ValueObjects;
using DDDSkeletonNET.Portal.Repository.Memory.Database;

namespace DDDSkeletonNET.Portal.Repository.Memory.Repositories
{
	public class CustomerRepository : Repository<Customer, int, DatabaseCustomer>, ICustomerRepository
	{
		public CustomerRepository(IUnitOfWork unitOfWork, IObjectContextFactory objectContextFactory) : base(unitOfWork, objectContextFactory)
		{}

		public override Customer FindBy(int id)
		{
			DatabaseCustomer databaseCustomer = (from dc in ObjectContextFactory.Create().DatabaseCustomers
												 where dc.Id == id
												 select dc).FirstOrDefault();
			if (databaseCustomer != null)
			{
				return ConvertToDomain(databaseCustomer);
			}
			return null;
		}

		public override DatabaseCustomer ConvertToDatabaseType(Customer domainType)
		{
			return new DatabaseCustomer()
			{
				Address = domainType.CustomerAddress.AddressLine1
				,City = domainType.CustomerAddress.City
				,Country = "N/A"
				,CustomerName = domainType.Name
				,Id = domainType.Id
				,Telephone = "N/A"
			};
		}

		public IEnumerable<Customer> FindAll()
		{
			List<Customer> allCustomers = new List<Customer>();
			List<DatabaseCustomer> allDatabaseCustomers = (from dc in ObjectContextFactory.Create().DatabaseCustomers
														   select dc).ToList();
			foreach (DatabaseCustomer dc in allDatabaseCustomers)
			{
				allCustomers.Add(ConvertToDomain(dc));
			}
			return allCustomers;
		}

		private Customer ConvertToDomain(DatabaseCustomer databaseCustomer)
		{
			Customer customer = new Customer()
			{
				Id = databaseCustomer.Id
				,Name = databaseCustomer.CustomerName
				,CustomerAddress = new Address()
				{
					AddressLine1 = databaseCustomer.Address
					,AddressLine2 = string.Empty
					,City = databaseCustomer.City
					,PostalCode = "N/A"
				}
			};
			return customer;
		}
	}
}
