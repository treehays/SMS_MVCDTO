using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;
        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Customer Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(string staffId)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Customer Login(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer UpdatePassword(Customer customer)
        {
            throw new NotImplementedException();
        }
        //public Customer Create(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return customer;
        //}

        //public void Delete(Customer customer)
        //{
        //    _context.Customers.Remove(customer);
        //    _context.SaveChanges();
        //}

        //public IList<Customer> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer GetByEmail(string email)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer GetById(string staffId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<Customer> GetByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer GetPhoneNumber(string phoneNumber)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer Login(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer Update(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer UpdatePassword(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
