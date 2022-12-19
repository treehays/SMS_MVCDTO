namespace SMS_MVCDTO.Models.Entities
{
    public class Wallet : BaseEntity
    {
        public Attendant Attendant { get; set; }
        public int AttendantId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        //public IList<Transaction> Transactions { get; set; }
        //public string TransactionId { get; set; }
    }
}
