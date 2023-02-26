using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Cart Create(Cart cart);
        int Update(int customerId);
        void Delete(Cart cart);
        IEnumerable<Cart> GetAll();
        IEnumerable<Cart> GetAllPendingTransaction();
        IEnumerable<Cart> NotPaidByCustomerId(int customerId);
        double GetCartTotal(int customerId);
        IEnumerable<Cart> GetByTransactionId(int transactionId);
        Cart GetById(int id);
        Cart NotPaidExist(int customerId);
        //IEnumerable<Cart> GetAllOrderByDate();
        /*        IEnumerable<Cart> GetByTransactionRef(int id);
                IEnumerable<Cart> GetTransactionByCustomerName(string customerName);
        */
    }
}
