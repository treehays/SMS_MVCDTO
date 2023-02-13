
using SMS_MVCDTO.Models.DTOs.CartDTOs;
using SMS_MVCDTO.Models.DTOs.ProductDTOs;

namespace SMS_MVCDTO.Models.ViewModels
{
    public class AddToCartProductViewModel
    {
        public double TempTotal { get; set; }
        public ProductResponseModel Product { get; set; }
        public CreateCartRequestModel CartRequestModel { get; set; }
    }
}
