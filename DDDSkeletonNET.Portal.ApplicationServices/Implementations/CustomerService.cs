using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.ApplicationServices.Exceptions;
using DDDSkeletonNET.Portal.ApplicationServices.Interfaces;
using DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers;
using DDDSkeletonNET.Portal.Domain.Customer;
using DDDSkeletonNET.Portal.Domain.ValueObjects;

namespace DDDSkeletonNET.Portal.ApplicationServices.Implementations
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
		{
			if (customerRepository == null) throw new ArgumentNullException("Customer repo");
			if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
			_customerRepository = customerRepository;
			_unitOfWork = unitOfWork;
		}

		public GetCustomerResponse GetCustomer(GetCustomerRequest getCustomerRequest)
		{
			GetCustomerResponse getCustomerResponse = new GetCustomerResponse();
			Customer customer = null;
			try
			{
				customer = _customerRepository.FindBy(getCustomerRequest.Id);
				if (customer == null)
				{
					getCustomerResponse.Exception = GetStandardCustomerNotFoundException();
				}
				else
				{
					getCustomerResponse.Customer = customer.ConvertToViewModel();
				}
			}
			catch (Exception ex)
			{
				getCustomerResponse.Exception = ex;
			}
			return getCustomerResponse;
		}

		public GetCustomersResponse GetAllCustomers()
		{
			GetCustomersResponse getCustomersResponse = new GetCustomersResponse();
			IEnumerable<Customer> allCustomers = null;

			try
			{
				allCustomers = _customerRepository.FindAll();
				getCustomersResponse.Customers = allCustomers.ConvertToViewModels();
			}
			catch (Exception ex)
			{
				getCustomersResponse.Exception = ex;
			}
			return getCustomersResponse;
		}

		public InsertCustomerResponse InsertCustomer(InsertCustomerRequest insertCustomerRequest)
		{
			Customer newCustomer = AssignAvailablePropertiesToDomain(insertCustomerRequest.CustomerProperties);
			ThrowExceptionIfCustomerIsInvalid(newCustomer);
			try
			{
				_customerRepository.Insert(newCustomer);				
				_unitOfWork.Commit();
				return new InsertCustomerResponse();
			}
			catch (Exception ex)
			{
				return new InsertCustomerResponse() { Exception = ex };
			}
		}		

		public UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
		{
			try
			{
				Customer existingCustomer = _customerRepository.FindBy(updateCustomerRequest.Id);
				if (existingCustomer != null)
				{
					Customer assignableProperties = AssignAvailablePropertiesToDomain(updateCustomerRequest.CustomerProperties);
					existingCustomer.CustomerAddress = assignableProperties.CustomerAddress;
					existingCustomer.Name = assignableProperties.Name;
					ThrowExceptionIfCustomerIsInvalid(existingCustomer);
					_customerRepository.Update(existingCustomer);
					_unitOfWork.Commit();
					return new UpdateCustomerResponse();
				}
				else
				{
					return new UpdateCustomerResponse() { Exception = GetStandardCustomerNotFoundException() };
				}
			}
			catch (Exception ex)
			{
				return new UpdateCustomerResponse() { Exception = ex };
			}
		}

		public DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest deleteCustomerRequest)
		{
			try
			{
				Customer customer = _customerRepository.FindBy(deleteCustomerRequest.Id);
				if (customer != null)
				{
					_customerRepository.Delete(customer);
					_unitOfWork.Commit();
					return new DeleteCustomerResponse();
				}
				else
				{
					return new DeleteCustomerResponse() { Exception = GetStandardCustomerNotFoundException() };
				}
			}
			catch (Exception ex)
			{
				return new DeleteCustomerResponse() { Exception = ex };
			}
		}

		private ResourceNotFoundException GetStandardCustomerNotFoundException()
		{
			return new ResourceNotFoundException("The requested customer was not found.");
		}

		private Customer AssignAvailablePropertiesToDomain(CustomerPropertiesViewModel customerProperties)
		{
			Customer customer = new Customer();
			customer.Name = customerProperties.Name;
			Address address = new Address();
			address.AddressLine1 = customerProperties.AddressLine1;
			address.AddressLine2 = customerProperties.AddressLine2;
			address.City = customerProperties.City;
			address.PostalCode = customerProperties.PostalCode;
			customer.CustomerAddress = address;
			return customer;
		}

		private void ThrowExceptionIfCustomerIsInvalid(Customer newCustomer)
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
