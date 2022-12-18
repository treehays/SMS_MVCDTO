using SMS_MVCDTO.DTOs.CustomerDTOs;
using SMS_MVCDTO.DTOs.UserDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ICustomerService
    {
        //Customer Create(Customer customer);
        //Customer Login(Customer customer);
        //void Delete(Customer customer);
        //Customer GetById(string staffId);
        //Customer GetByEmail(string email);
        //Customer GetPhoneNumber(string phoneNumber);
        //IList<Customer> GetByName(string name);
        //IList<Customer> GetAll();
        //Customer Update(Customer customer);
        //Customer UpdatePassword(Customer customer);


        CustomerDTO CreateCustomer(CreateCustomerRequestModel model);
        CustomerDTO UpdateCustomer(UpdateCustomerRequestModel model);
        CustomerDTO UpdateCustomerPasswordDTO (UpdateCustomerPasswordRequestModel model);
        CustomerDTO LoginCustomer(LoginRequestModel model);
        void DeleteCustomer(string customerId);
        CustomerDTO GetById(string customerId);
        CustomerDTO GetByEmail(string email);
        CustomerDTO GetPhoneNumber(string phoneNumber);
        IList<CustomerDTO> GetByName(string name);
        IList<CustomerDTO> GetAll();
    }
}
