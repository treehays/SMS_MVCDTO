using SMS_MVCDTO.DTOs.TransactionDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ITransactionService
    {
        CreateTransactionRequestModel Create(CreateTransactionRequestModel transaction);
        //Transaction Update(Transaction transaction);
        void Delete(string refNumber);
        IEnumerable<TransactionResponseModel> GetAll();
        IEnumerable<TransactionResponseModel> GetByDate(DateTime dateTime);
        TransactionResponseModel GetById(string refrenceNo);
        IEnumerable<TransactionResponseModel> GetByStaffId(string staffId);
        IEnumerable<TransactionResponseModel> GetTransactionByCustomerName(string customerName);
        //IEnumerable<TransactionResponseModel> DownloadExcel();

    }
}
