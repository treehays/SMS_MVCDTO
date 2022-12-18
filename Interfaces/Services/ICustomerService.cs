using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Login(Customer customer);
        void Delete(Customer customer);
        Customer GetById(string staffId);
        Customer GetByEmail(string email);
        Customer GetPhoneNumber(string phoneNumber);
        IList<Customer> GetByName(string name);
        IList<Customer> GetAll();
        Customer Update(Customer customer);
        Customer UpdatePassword(Customer customer);
    }
}
