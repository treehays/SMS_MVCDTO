using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.Entities
{
    [Index(nameof(StaffId), IsUnique = true)]
    public class User : BaseEntity
    {
        public SalesManager SalesManager { get; set; }
        public SuperAdmin SuperAdmin { get; set; }
        public Customer Customer { get; set; }
        public Attendant Attendant { get; set; }
        [Required]
        [Key]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRoleType Role { get; set; }


        public static string GenerateRandomId(string secondLetter)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            var r1 = new Random().Next(25);
            var r2 = new Random().Next(25);
            var staffId = $"{secondLetter}{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000);
            return staffId;
        }
        //public IList<Transaction> Transactions { get; set; }
        //public Wallet Wallets { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Pin { get; set; }
        //public string PhoneNumber { get; set; }
        //public string HomeAddress { get; set; }
        //public string ResidentialAddress { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public GenderType Gender { get; set; }
        //public MaritalStatusType MaritalStatus { get; set; }
        //public UserRoleType userRole { get; set; }
        //public string BankAccountNumber { get; set; }
        //public string BankName { get; set; }
        //public string GuarantorName { get; set; }
        //public string GuarantorPhoneNumber { get; set; }
        /*
         parent,upload photo, upload proof of residence, valid id card
         */
    }
}
