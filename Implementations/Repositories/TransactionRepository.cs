using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Customer Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> DownloadExcel()
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetByCustomerName(string customer)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetByDate()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetByStaffId(string staffId)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
