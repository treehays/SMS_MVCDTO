namespace SMS_MVCDTO.Models.Entities
{
    public class Address : BaseEntity
    {
        //public int AttendantId { get; set; }
        //  public Attendant Attendant { get; set; }
        //  public int SuperAdminId { get; set; }
        //  public SuperAdmin SuperAdmin { get; set; }
        //  public SalesManager SalesManager { get; set; }
        //   public int SalesManagerId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
