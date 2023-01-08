using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;

namespace SMS_MVCDTO.ViewModels
{
    public class ProductTransactionViewModel
    {
        public double TempTotal { get; set; }
        public ProductResponseModel Product{ get; set; }
        public CreateTransactionRequestModel Transaction{ get; set; }
    }
}
