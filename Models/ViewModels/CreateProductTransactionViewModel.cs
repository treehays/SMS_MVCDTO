using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;

namespace SMS_MVCDTO.Models.ViewModels
{
    /// <summary>
    /// May be deleted later
    /// </summary>
    public class CreateProductTransactionViewModel
    {
        public double TempTotal { get; set; }
        public ProductResponseModel Product { get; set; }
        public CreateTransactionRequestModel Transaction { get; set; }
    }
}
