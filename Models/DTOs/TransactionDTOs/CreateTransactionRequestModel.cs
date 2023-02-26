namespace SMS_MVCDTO.Models.DTOs.TransactionDTOs
{
    /// <summary>
    /// Maybe deleted later
    /// </summary>
    public class CreateTransactionRequestModel
    {
        //public string ReferenceNo { get; set; }
        public int AttendanId { get; set; }
        public int CustomerId { get; set; }
        public double CashTender { get; set; }
        public int CartId { get; set; }
        //public string BarCode { get; set; }
        //public int Quantity { get; set; }
        public string CustomeName { get; set; }
        public double TotalAmount { get; set; }
    }
}
