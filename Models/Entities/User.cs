namespace SMS_MVCDTO.Models.Entities
{
    public class User : BaseEntity 
    {
        public string StaffId { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public Wallet Wallets { get; set; }
        public string WalletId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
    }
}
