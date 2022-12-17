namespace SMS_MVCDTO.Models.Entities
{
    public class ProductTransaction
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string TransactionId { get; set; }
        public Product Product { get; set; }
        public Transaction Transaction { get; set; }
    }
}
