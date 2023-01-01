namespace SMS_MVCDTO.Models.Entities
{
    public class Wallet : BaseEntity
    {
        public int Id { get; set; }
        public Attendant Attendant { get; set; }
        public string AttendantId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
    
    }
}
