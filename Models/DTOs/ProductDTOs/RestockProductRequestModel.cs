namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class RestockProductRequestModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public double Quantity { get; set; }
    }

}
