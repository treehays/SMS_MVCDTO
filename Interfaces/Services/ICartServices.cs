using SMS_MVCDTO.Models.DTOs.CartDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ICartServices
    {
        CreateCartRequestModel Create(CreateCartRequestModel cart);
        //string Update(int customerId);
        void Delete(int id);
        IEnumerable<CartResponseModel> GetAll();
        IEnumerable<CartResponseModel> GetAllPendingTransaction();

        IEnumerable<CartResponseModel> NotPaidByCustomerId(int customerId);
        IEnumerable<CartResponseModel> GetByTransactionId(int transactionId);
        CartResponseModel GetById(int id);
        CartResponseModel NotPaidExist(int customerId);
        double GetCartTotal(int customerId);

        //IEnumerable<Cart> GetAllOrderByDate();
        /* CartResponseModel GetById(int id);
         IEnumerable<CartResponseModel> GetByTransactionRef(int id);
         IEnumerable<CartResponseModel> GetTransactionByCustomerName(string customerName);*/
    }
}
