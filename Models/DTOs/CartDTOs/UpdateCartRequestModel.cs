namespace SMS_MVCDTO.Models.DTOs.CartDTOs
{
    public class UpdateCartRequestModel
    {
        //public string ProductId { get; set; }
        //public string CustomermId { get; set; }
        public string TransactionId { get; set; }
        //public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
    }
}
