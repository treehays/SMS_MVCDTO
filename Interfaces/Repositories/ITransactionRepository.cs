using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        Transaction Update(Transaction transaction);
        void Delete(Transaction transaction);
        IEnumerable<Transaction> GetAll();
        IEnumerable<Transaction> GetByDate();
        Transaction GetById(string Id);
        IEnumerable<Transaction> GetByStaffId(string staffId);
        IEnumerable<Transaction> GetTransactionByCustomerName(string transaction);
        IEnumerable<Transaction> DownloadExcel();

    }
}
