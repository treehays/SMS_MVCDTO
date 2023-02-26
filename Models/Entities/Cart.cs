namespace SMS_MVCDTO.Models.Entities
{
    public class Cart : BaseEntity
    {
        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        //public double Price { get; set; }

    }
}
