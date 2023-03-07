namespace SMS_MVCDTO.Models.Entities
{
    public class AttendantCustomer : BaseEntity
    {
        public string AttendantId { get; set; }
        public Attendant Attendant { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
