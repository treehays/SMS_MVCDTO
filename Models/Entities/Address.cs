namespace SMS_MVCDTO.Models.Entities
{
    public class Address : BaseEntity
    {
        public int AttendantId { get; set; }
        public Attendant Attendant { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
