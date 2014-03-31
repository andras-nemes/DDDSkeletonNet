using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Caching;
using DDDSkeletonNET.Infrastructure.Common.Configuration;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.ApplicationServices.Interfaces;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers;

namespace DDDSkeletonNET.Portal.ApplicationServices.Implementations
{
	public class EnrichedCustomerService : ICustomerService
	{
		private readonly ICustomerService _innerCustomerService;
		private readonly ICacheStorage _cacheStorage;
		private readonly IConfigurationRepository _configurationRepository;

		public EnrichedCustomerService(ICustomerService innerCustomerService, ICacheStorage cacheStorage
			, IConfigurationRepository configurationRepository)
		{
			if (innerCustomerService == null) throw new ArgumentNullException("CustomerService");
			if (cacheStorage == null) throw new ArgumentNullException("CacheStorage");
			if (configurationRepository == null) throw new ArgumentNullException("ConfigurationRepository");
			_innerCustomerService = innerCustomerService;
			_cacheStorage = cacheStorage;
			_configurationRepository = configurationRepository;
		}

		public GetCustomerResponse GetCustomer(GetCustomerRequest getCustomerRequest)
		{
			return _innerCustomerService.GetCustomer(getCustomerRequest);
		}

		public GetCustomersResponse GetAllCustomers()
		{
			string key = "GetAllCustomers";
			GetCustomersResponse response = _cacheStorage.Retrieve<GetCustomersResponse>(key);
			if (response == null)
			{
				int cacheDurationSeconds = _configurationRepository.GetConfigurationValue<int>("ShortCacheDuration");
				response = _innerCustomerService.GetAllCustomers();
				_cacheStorage.Store(key, response, TimeSpan.FromSeconds(cacheDurationSeconds));
			}
			return response;
		}

		public InsertCustomerResponse InsertCustomer(InsertCustomerRequest insertCustomerRequest)
		{
			return _innerCustomerService.InsertCustomer(insertCustomerRequest);
		}

		public UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
		{
			return _innerCustomerService.UpdateCustomer(updateCustomerRequest);
		}

		public DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest deleteCustomerRequest)
		{
			return _innerCustomerService.DeleteCustomer(deleteCustomerRequest);
		}
	}
}
