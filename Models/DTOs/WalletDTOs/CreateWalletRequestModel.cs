namespace SMS_MVCDTO.Models.DTOs.WalletDTOs
{
    public class CreateWalletRequestModel
    {
        public double Debit { get; set; }
        public int CustomerId { get; set; }
        public double Credit { get; set; }
    }

}
