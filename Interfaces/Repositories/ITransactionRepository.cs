using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        //Transaction Update(Transaction transaction);
        void Delete(Transaction transaction);
        IEnumerable<Transaction> GetAll();
        IEnumerable<Transaction> GetAllOrderByDate();
        IEnumerable<Transaction> GetByDate(DateTime dateTime);
        Transaction GetById(string refNumber);
        IEnumerable<Transaction> GetByStaffId(string staffId);
        IEnumerable<Transaction> GetTransactionByCustomerName(string customerName);
        //IEnumerable<Transaction> DownloadExcel();

    }
}
