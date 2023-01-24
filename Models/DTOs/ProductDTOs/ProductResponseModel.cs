using System.ComponentModel;

namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class ProductResponseModel : BaseResponse
    {

        public ProductDTOs Data { get; set; }
    }

}
