using SMS_MVCDTO.DTOs.CustomerDTOs;
using SMS_MVCDTO.DTOs.UserDTOs;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDTO CreateCustomer(CreateCustomerRequestModel model)
        {
            throw new NotImplementedException();
            var customerExist = _customerRepository.GetByEmail(model.Email);
            if (customerExist == null)
            {
                var customer = new Customer
                { 
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,

                };

            }
        }

        public void DeleteCustomer(string customerId)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetById(string customerId)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO LoginCustomer(LoginRequestModel model)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO UpdateCustomer(UpdateCustomerRequestModel model)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO UpdateCustomerPasswordDTO(UpdateCustomerPasswordRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
