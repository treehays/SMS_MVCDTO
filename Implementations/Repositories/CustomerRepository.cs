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
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public Customer GetByEmail(string email)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == email);
            return customer;
        }

        public Customer GetById(string staffId)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.StaffId == staffId);
            return customer;
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            var customers = _context.Customers.Where(w => w.IsActive == true && w.IsDeleted == false && name.All(x => (w.LastName + w.FirstName).Contains(x)));
            return customers;
        }

        public Customer GetByPhoneNumber(string phoneNumber)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers.Where(w => w.IsDeleted == false && w.IsActive == true);
            return customers;
        }

        //public Customer Login(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}


        public Customer Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }


        public Customer UpdatePassword(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }

    }
}
