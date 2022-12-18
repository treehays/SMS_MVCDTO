using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.Models.Entities
{
    public class User : BaseEntity 
    {
        public IList<Transaction> Transactions { get; set; }
        public Wallet Wallets { get; set; }
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public UserRoleType userRole { get; set; }
        //for staffs
        //public IList<Transaction> Transactions { get; set; }
        //public Wallet Wallets { get; set; }
        //public User User { get; set; }
        //public string UserId { get; set; }



        /*
         parent,upload photo, upload proof of residence, valid id card
         */
    }
}
