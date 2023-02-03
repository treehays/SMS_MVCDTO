using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;

namespace SMS_MVCDTO.Models.ViewModels
{
    public class TransactionProductListsViewModel
    {
        public IEnumerable<TransactionResponseModel> Transaction { get; set; }
        public IEnumerable<ProductResponseModel> Product { get; set; }
    }
}
