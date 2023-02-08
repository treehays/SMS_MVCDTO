using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    public class Customer : BaseEntity
    {

        public User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public Wallet Wallets { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Attendant> Attendants { get; set; }
        [Required]
        [Key]
        public string StaffId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public UserRoleType userRole { get; set; }
        //public IList<Transaction> Transactions { get; set; }
    }
}
