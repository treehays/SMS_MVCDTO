namespace SMS_MVCDTO.DTOs.WalletDTOs
{
    public class WalletDTOs
    {
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
    }

    public class CreateWalletRequestModel
    {
        public double Debit { get; set; }
        public double Credit { get; set; }
    }

    public class UpdateWalletRequestModel
    {
        public double Debit { get; set; }
        public double Credit { get; set; }
    }

}
