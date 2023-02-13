namespace SMS_MVCDTO.Models.Entities
{
    public class Cart : BaseEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string CustomermId { get; set; }
        public string TransactionId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
    }
}
