using SMS_MVCDTO.Enums;


namespace SMS_MVCDTO.Models.Entities
{
    //[Index(nameof(Email), IsUnique = true)]
    //[Index(nameof(PhoneNumber), IsUnique = true)]
    public class SalesManager : BaseEntity
    {
        public ICollection<Attendant> Attendants { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CVPath { get; set; }
        public Address Address { get; set; }
        public BankDetail BankDetail { get; set; }


        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
    }
}
