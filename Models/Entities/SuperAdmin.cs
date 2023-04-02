
using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    /*    [Index(nameof(Email), IsUnique = true)]
        [Index(nameof(PhoneNumber), IsUnique = true)]*/
    public class SuperAdmin : BaseEntity
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        //[ForeignKey(nameof(User))]
        //public BankDetail BankDetail { get; set; }
        //   public Address Address { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string BankAccountNumber { get; set; }
        //public string BankName { get; set; }
    }
}
