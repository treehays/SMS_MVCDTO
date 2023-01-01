using SMS_MVCDTO.Models.DTOs.CustomerDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ICustomerService
    {
        CreateCustomerRequestModel Create(CreateCustomerRequestModel customer);
        //Customer Login(Customer customer);
        void Delete(string staffId);
        CustomerResponseModel GetById(string staffId);
        CustomerResponseModel GetByEmail(string email);
        CustomerResponseModel GetByPhoneNumber(string phoneNumber);
        IEnumerable<CustomerResponseModel> GetByName(string name);
        IEnumerable<CustomerResponseModel> GetCustomers();
        CustomerResponseModel Update(CustomerResponseModel customer);
        UpdateCustomerPasswordRequestModel UpdatePassword(UpdateCustomerPasswordRequestModel customer);
    }
}
