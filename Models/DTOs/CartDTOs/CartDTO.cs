namespace SMS_MVCDTO.Models.DTOs.CartDTOs
{
    public class CartDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        public double Total { get; set; }
        public double ProductPrice { get; set; }
    }
}
