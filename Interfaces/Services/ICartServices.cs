using SMS_MVCDTO.Models.DTOs.CartDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ICartServices
    {
        CreateCartRequestModel Create(CreateCartRequestModel cart);
        IEnumerable<UpdateCartRequestModel> Update(string customerId);
        void Delete(int id);
        IEnumerable<CartResponseModel> GetAll();
        IEnumerable<CartResponseModel> GetAllPendingTransaction();

        IEnumerable<CartResponseModel> NotPaidByCustomerId(string customerId);
        IEnumerable<CartResponseModel> GetByTransactionId(string transactionId);
        CartResponseModel GetById(int id);
        CartResponseModel NotPaidExist(string customerId);
        double GetCartTotal(string customerId);

        //IEnumerable<Cart> GetAllOrderByDate();
        /* CartResponseModel GetById(int id);
         IEnumerable<CartResponseModel> GetByTransactionRef(int id);
         IEnumerable<CartResponseModel> GetTransactionByCustomerName(string customerName);*/
    }
}
