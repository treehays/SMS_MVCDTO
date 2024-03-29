﻿using SMS_MVCDTO.Models.DTOs.CartDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ICartServices
    {
        CreateCartRequestModel Create(CreateCartRequestModel cart);
        //string Update(int customerId);
        void Delete(string id);
        IEnumerable<CartResponseModel> GetAll();
        IEnumerable<CartResponseModel> GetAllPendingTransaction();

        IEnumerable<CartResponseModel> NotPaidByCustomerId(string customerId);
        IEnumerable<CartResponseModel> GetByTransactionId(string transactionId);
        CartResponseModel GetById(string id);
        CartResponseModel NotPaidExist(string customerId);
        double GetCartTotal(string customerId);

        //IEnumerable<Cart> GetAllOrderByDate();
        /* CartResponseModel GetById(int id);
         IEnumerable<CartResponseModel> GetByTransactionRef(int id);
         IEnumerable<CartResponseModel> GetTransactionByCustomerName(string customerName);*/
    }
}
