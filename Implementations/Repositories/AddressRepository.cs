using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationContext _context;

        public AddressRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Address Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            //_context.Entry(address).State = EntityState.Added;

            return address;
        }

        public void Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public Address GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Address Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
