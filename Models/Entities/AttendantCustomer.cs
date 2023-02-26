namespace SMS_MVCDTO.Models.Entities
{
    public class AttendantCustomer : BaseEntity
    {
        public int AttendantId { get; set; }
        public Attendant Attendant { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
