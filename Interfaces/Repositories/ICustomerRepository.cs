using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        //Customer Login(Customer customer);
        void Delete(Customer customer);
        Customer GetById(string staffId);
        Customer GetByEmail(string email);
        Customer GetByPhoneNumber(string phoneNumber);
        IEnumerable<Customer> GetByName(string name);
        IEnumerable<Customer> GetCustomers();
        Customer Update(Customer customer);
        Customer UpdatePassword(Customer customer);
    }
}
