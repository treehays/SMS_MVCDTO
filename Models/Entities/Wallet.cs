namespace SMS_MVCDTO.Models.Entities
{
    public class Wallet : BaseEntity
    {
        public IList<Transaction> Transactions { get; set; }
        public string TransactionId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
    }
}
