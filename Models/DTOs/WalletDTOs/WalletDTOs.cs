namespace SMS_MVCDTO.DTOs.WalletDTOs
{
    public class WalletDTOs
    {
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string CustomerId { get; set; }
    }

    public class CreateWalletRequestModel
    {
        public double Debit { get; set; }
        public string CustomerId { get; set; }
        public double Credit { get; set; }
    }

    public class DebitWalletRequestModel
    {
        public double Debit { get; set; }
        public string CustomerId { get; set; }
        //public double Credit { get; set; }
    }
    
    public class CreditWalletRequestModel
    {
        //public double Debit { get; set; }
        public string CustomerId { get; set; }
        public double Credit { get; set; }
    }

}
