using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.ApplicationServices.Interfaces;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging.EnhancedCustomers;
using DDDSkeletonNET.Portal.Domain.Customer;
using DDDSkeletonNET.Portal.Domain.Factories;

namespace DDDSkeletonNET.Portal.ApplicationServices.Implementations
{
	public class CountrySpecificCustomerService : ApplicationServiceBase, ICountrySpecificCustomerService
	{
		private readonly ICountrySpecificCustomerRepository _repository;
		private readonly ICountryFactory _countryFactory;

		public CountrySpecificCustomerService(IUnitOfWork unitOfWork, ICountrySpecificCustomerRepository repository
			, ICountryFactory countryFactory) : base(unitOfWork)
		{
			if (repository == null) throw new ArgumentNullException("CountrySpecificCustomerRepository");
			if (countryFactory == null) throw new ArgumentNullException("ICountryFactory");
			_repository = repository;
			_countryFactory = countryFactory;
		}

		public InsertCountrySpecificCustomerResponse InsertCountrySpecificCustomer(InsertCountrySpecificCustomerRequest insertCustomerRequest)
		{
			CountrySpecificCustomer newCustomer = BuildCountrySpecificCustomer(insertCustomerRequest.CountrySpecificCustomer);
			ThrowExceptionIfCustomerIsInvalid(newCustomer);
			try
			{
				_repository.Insert(newCustomer);
				UnitOfWork.Commit();
				return new InsertCountrySpecificCustomerResponse();
			}
			catch (Exception ex)
			{
				return new InsertCountrySpecificCustomerResponse() { Exception = ex };
			}
		}

		private CountrySpecificCustomer BuildCountrySpecificCustomer(CountrySpecificCustomerViewModel viewModel)
		{
			return new CountrySpecificCustomer(_countryFactory.CreateCountry(viewModel.CountryCode))
			{
				Age = viewModel.Age
				, Email = viewModel.Email
				, FirstName = viewModel.FirstName
				, NickName = viewModel.NickName
			};
		}

		private void ThrowExceptionIfCustomerIsInvalid(CountrySpecificCustomer newCustomer)
		{
			IEnumerable<BusinessRule> brokenRules = newCustomer.GetBrokenRules();
			if (brokenRules.Count() > 0)
			{
				StringBuilder brokenRulesBuilder = new StringBuilder();
				brokenRulesBuilder.AppendLine("There were problems saving the LoadtestPortalCustomer object:");
				foreach (BusinessRule businessRule in brokenRules)
				{
					brokenRulesBuilder.AppendLine(businessRule.RuleDescription);
				}

				throw new Exception(brokenRulesBuilder.ToString());
			}
		}
	}
}
