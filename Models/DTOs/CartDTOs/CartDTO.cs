namespace SMS_MVCDTO.Models.DTOs.CartDTOs
{
    public class CartDTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CustomermId { get; set; }
        public string TransactionId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        public double Total { get; set; }
        public double ProductPrice { get; set; }
    }
}
