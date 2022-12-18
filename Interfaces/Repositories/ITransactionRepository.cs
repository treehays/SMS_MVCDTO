using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Create (Transaction transaction);
        Transaction Update (Transaction transaction);
        void Delete (Transaction transaction);
        IList<Transaction> GetAll ();
        IList<Transaction> GetByDate ();
        Transaction GetById(string Id);
        IList<Transaction> GetByStaffId (string staffId);
        IList<Transaction> GetByTransactionName (string transaction);
        IList<Transaction> DownloadExcel ();

    }
}
