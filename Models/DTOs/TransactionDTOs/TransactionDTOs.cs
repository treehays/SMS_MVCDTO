namespace SMS_MVCDTO.Models.DTOs.TransactionDTOs
{
    public class TransactionDTOs
    {
        public DateTime Created { get; set; }
        public string ReferenceNo { get; set; }
        public string AttendantId { get; set; }
        public string CustomerId { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public string CustomerName { get; set; }

    }
}
