namespace SMS_MVCDTO.DTOs.ProductDTOs
{
    public class ProductDTOs
    {
    }

    public class CreateProductRequestModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
    }


    public class UpdateProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
    }

    public class RestockProductRequestModel
    {
        public int Quantity { get; set; }
    }

}
