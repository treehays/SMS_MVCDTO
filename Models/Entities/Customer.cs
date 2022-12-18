namespace SMS_MVCDTO.Models.Entities
{
    public class Customer : BaseEntity 
    {
        //public IList<Transaction> Transactions { get; set; }
        //public Wallet Wallets { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Pin { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Address { get; set; }
        //public bool Status { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public GenderType Gender { get; set; }
        //public MaritalStatusType MaritalStatus { get; set; }
        //public UserRoleType userRole { get; set; }
    }
}
