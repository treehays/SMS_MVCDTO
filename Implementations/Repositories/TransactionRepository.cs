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
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public void Delete(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

        //public IEnumerable<Transaction> DownloadExcel()
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Transaction> GetAll()
        {
            var transactions = _context.Transactions.Where(a => a.IsDeleted == false);
            return transactions;
        }

        public IEnumerable<Transaction> GetByDate(DateTime dateTime)
        {
            var transactions = _context.Transactions.Where(a => a.IsDeleted == false && a.Created.Day == dateTime.Day);
            return transactions;
        }

        public Transaction GetById(string refNumber)
        {
            var transaction = _context.Transactions.SingleOrDefault(a => a.ReferenceNo == refNumber);
            return transaction;
        }

        public IEnumerable<Transaction> GetByStaffId(string staffId)
        {
            var transactions = _context.Transactions.Where(a => a.CustomerId == staffId);
            return transactions;
        }

        public IEnumerable<Transaction> GetTransactionByCustomerName(string customerName)
        {
            var transactions = _context.Transactions.Where(a => customerName.All(b => (a.Customer.FirstName + a.Customer.LastName).Contains(b)));
            return transactions;
        }

        //public Transaction Update(Transaction transaction)
        //{
        //    _context.Transactions.Update(transaction);
        //    _context.SaveChanges();
        //    return transaction;
        //}
    }
}
