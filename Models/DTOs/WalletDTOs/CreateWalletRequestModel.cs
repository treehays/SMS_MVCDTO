namespace SMS_MVCDTO.Models.DTOs.WalletDTOs
{
    public class CreateWalletRequestModel
    {
        public double Debit { get; set; }
        public string CustomerId { get; set; }
        public double Credit { get; set; }
    }

}
