namespace SMS_MVCDTO.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public string RefrenceNumber { get; set; }
        public string ProductId { get; set; }
        public IList<ProductTransaction> ProductTransactions { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
    }
}
