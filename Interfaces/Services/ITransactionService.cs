using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ITransactionService
    {
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        void Delete(Customer customer);
        IList<Customer> GetAll();
        IList<Customer> GetByDate();
        Customer GetById(string Id);
        IList<Customer> GetByStaffId(string staffId);
        IList<Customer> GetByCustomerName(string customer);
        IList<Customer> DownloadExcel();
    }
}
