namespace SMS_MVCDTO.Models.DTOs.CartDTOs
{
    public class CreateCartRequestModel
    {
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        //public string TransactionId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
    }
}
