using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _context;
        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Transaction Create(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> DownloadExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetByDate()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetByStaffId(string staffId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactionByCustomerName(string transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
