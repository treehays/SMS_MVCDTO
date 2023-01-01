namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class UpdateProductRequestModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        //public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
    }

}
