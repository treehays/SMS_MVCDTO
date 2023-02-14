using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Cart Create(Cart cart);
        string Update(string customerId);
        void Delete(Cart cart);
        IEnumerable<Cart> GetAll();
        IEnumerable<Cart> GetAllPendingTransaction();
        IEnumerable<Cart> NotPaidByCustomerId(string customerId);
        double GetCartTotal(string customerId);
        IEnumerable<Cart> GetByTransactionId(string transactionId);
        Cart GetById(int id);
        Cart NotPaidExist(string customerId);
        //IEnumerable<Cart> GetAllOrderByDate();
        /*        IEnumerable<Cart> GetByTransactionRef(int id);
                IEnumerable<Cart> GetTransactionByCustomerName(string customerName);
        */
    }
}
