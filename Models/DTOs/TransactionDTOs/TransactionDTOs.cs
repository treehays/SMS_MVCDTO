namespace SMS_MVCDTO.DTOs.TransactionDTOs
{
    public class TransactionDTOs
    {
        public string ReferenceNo { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }

    }

    public class TransactionResponseModel : BaseResponse
    {
        public TransactionDTOs Data { get; set; }
    }

    public class CreateTransactionRequestModel
    {
        public int Quantity { get; set; }
        //public double TotalAmount { get; set; }
    }
}
