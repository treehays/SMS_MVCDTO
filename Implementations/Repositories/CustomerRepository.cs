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

        public bool CustomerExist(string staffId)
        {
            var customer = _context.Customers.Any(x => x.User.IsActive && !x.IsDeleted && x.User.StaffId == staffId);
            return customer;
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public Customer GetByEmail(string email)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.User.Email == email);
            return customer;
        }

        public Customer GetById(string id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.User.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            var customers = _context.Customers.Where(w => w.User.IsActive && !w.IsDeleted && name.All(x => (w.User.LastName + w.User.FirstName).Contains(x)));
            return customers;
        }

        public Customer GetByPhoneNumber(string phoneNumber)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.User.PhoneNumber == phoneNumber);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers.Where(w => w.IsDeleted == false && w.User.IsActive == true);
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
