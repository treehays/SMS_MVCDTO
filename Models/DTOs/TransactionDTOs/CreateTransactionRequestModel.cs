namespace SMS_MVCDTO.Models.DTOs.TransactionDTOs
{
    public class CreateTransactionRequestModel
    {
        public string ReferenceNo { get; set; }
        public string AttendantId { get; set; }
        public string CustomerId { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
    }
}
