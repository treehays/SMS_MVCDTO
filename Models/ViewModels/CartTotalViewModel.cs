using SMS_MVCDTO.Models.DTOs.CartDTOs;

namespace SMS_MVCDTO.Models.ViewModels
{
    public class CartTotalViewModel
    {
        public string CartId { get; set; }
        public double CartTotal { get; set; }
        public string CustomerId { get; set; }
        public IEnumerable<CartResponseModel> ListOfCartProduccts { get; set; }
    }
}
