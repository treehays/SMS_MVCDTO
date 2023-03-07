using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Enums;
namespace SMS_MVCDTO.Models.Entities
{
    //[Index(nameof(Email), IsUnique = true)]
    //[Index(nameof(PhoneNumber), IsUnique = true)]

    public class Attendant : BaseEntity
    {
        public SalesManager SalesManager { get; set; }
        public ICollection<AttendantCustomer> AttendantCustomers { get; set; } = new HashSet<AttendantCustomer>();
        public ICollection<Transaction> Transaction { get; set; } = new HashSet<Transaction>();
        public User User { get; set; }
        //public Address Address { get; set; }
        // public BankDetail BankDetail { get; set; }
        public string UserId { get; set; }
        public string SalesManagerID { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string CVPath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }

        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }

    }
}
