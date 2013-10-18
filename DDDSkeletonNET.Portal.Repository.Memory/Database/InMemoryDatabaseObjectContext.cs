using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
	public class InMemoryDatabaseObjectContext
	{
		//simulation of database collections
		public List<DatabaseCustomer> DatabaseCustomers 
		{ 
			get; 
			set; 
		}

		public InMemoryDatabaseObjectContext()
		{
			InitialiseDatabaseCustomers();
		}

		public void AddEntity<T>(T databaseEntity)
		{
			if (databaseEntity is DatabaseCustomer)
			{
				DatabaseCustomer databaseCustomer = databaseEntity as DatabaseCustomer;
				databaseCustomer.Id = DatabaseCustomers.Count + 1;
				DatabaseCustomers.Add(databaseCustomer);
			}
		}

		public void UpdateEntity<T>(T databaseEntity)
		{
			if (databaseEntity is DatabaseCustomer)
			{
				DatabaseCustomer dbCustomer = databaseEntity as DatabaseCustomer;
				DatabaseCustomer dbCustomerToBeUpdated = (from c in DatabaseCustomers where c.Id == dbCustomer.Id select c).FirstOrDefault();
				dbCustomerToBeUpdated.Address = dbCustomer.Address;
				dbCustomerToBeUpdated.City = dbCustomer.City;
				dbCustomerToBeUpdated.Country = dbCustomer.Country;
				dbCustomerToBeUpdated.CustomerName = dbCustomer.CustomerName;
				dbCustomerToBeUpdated.Telephone = dbCustomer.Telephone;
			}
		}

		public void DeleteEntity<T>(T databaseEntity)
		{
			if (databaseEntity is DatabaseCustomer)
			{
				DatabaseCustomer dbCustomer = databaseEntity as DatabaseCustomer;
				DatabaseCustomer dbCustomerToBeDeleted = (from c in DatabaseCustomers where c.Id == dbCustomer.Id select c).FirstOrDefault();
				DatabaseCustomers.Remove(dbCustomerToBeDeleted);
			}
		}

		private void InitialiseDatabaseCustomers()
		{
			DatabaseCustomers = new List<DatabaseCustomer>();
			DatabaseCustomers.Add(new DatabaseCustomer(){Address = "Main street", City = "Birmingham", Country = "UK", CustomerName ="GreatCustomer", Id = 1, Telephone = "N/A"});
			DatabaseCustomers.Add(new DatabaseCustomer() { Address = "Strandvägen", City = "Stockholm", Country = "Sweden", CustomerName = "BadCustomer", Id = 2, Telephone = "123345456" });
			DatabaseCustomers.Add(new DatabaseCustomer() { Address = "Kis utca", City = "Budapest", Country = "Hungary", CustomerName = "FavouriteCustomer", Id = 3, Telephone = "987654312" });
		}

		public static InMemoryDatabaseObjectContext Instance
		{
			get
			{
				return Nested.instance;
			}
		}

		private class Nested
		{
			static Nested()
			{
			}
			internal static readonly InMemoryDatabaseObjectContext instance = new InMemoryDatabaseObjectContext();
		}
	}
}
