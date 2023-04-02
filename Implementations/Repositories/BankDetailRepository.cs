using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class BankDetailRepository : IBankDetailRepository
    {
        private readonly ApplicationContext _context;

        public BankDetailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public BankDetail Create(BankDetail bankDetail)
        {
            _context.BankDetails.Add(bankDetail);
            _context.SaveChanges();
            //_context.Entry(bankDetail).State = EntityState.Added;
            //await _context.SaveChangesAsync();

            return bankDetail;
        }

        public void Delete(BankDetail bankDetail)
        {
            throw new NotImplementedException();
        }

        public BankDetail GetById(string id)
        {
            throw new NotImplementedException();
        }

        public BankDetail Update(BankDetail bankDetail)
        {
            throw new NotImplementedException();
        }
    }
}
