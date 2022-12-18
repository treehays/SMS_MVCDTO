namespace SMS_MVCDTO.Models.Entities
{
    public class Staff : BaseEntity
    {
        //public IList<Transaction> Transactions { get; set; }
        //public Wallet Wallets { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        //Attendant 
        public string ResidentialAddress { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
    }
}
