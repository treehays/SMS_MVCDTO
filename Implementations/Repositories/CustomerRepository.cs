using Microsoft.EntityFrameworkCore;
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
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public IList<Customer> GetAll()
        {
            var customers = _context.Customers.Include(x => x.Transactions).ToList();
            return customers;
        }

        public Customer GetByEmail(string email)
        {
            var customer = _context.Customers.Include(x => x.Transactions).SingleOrDefault(y => y.Email == email);
            return customer;
        }

        public Customer GetById(string staffId)
        {
            var customer = _context.Customers.Include(x => x.Transactions).SingleOrDefault(y => y.Id == staffId);
            return customer;
        }

        public IList<Customer> GetByName(string name)
        {
            //var customer = _context.Customers.Include(x => x.Transactions).Where(y => name.All(w = y.con))
            //var customer = _context.Customers.Where(x => x.FirstName.All(y => x.FirstName.Contains(name))).ToList();
            var customer1 = _context.Customers.Where(x => name.All(y => x.FirstName.Contains(y))).ToList();
            var customer2 = _context.Customers.Where(x => name.All(y => (x.FirstName + x.LastName).Contains(y))).ToList();
            var customer = _context.Customers.Include(m => m.Transactions).Where(x => name.All(y => (x.FirstName + x.LastName).Contains(y))).ToList();
            //var customer = _context.Customers.Where(x => x.FirstName.All(y => x.FirstName.Contains(name)));
            //var customer = _context.Customers.Include(x => x.Transactions.Where(x => x.))
            return customer;
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
    }
}
