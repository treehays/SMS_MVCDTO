namespace SMS_MVCDTO.DTOs.ProductCategoriesDTOs
{
    public class ProductCategoryDTOs
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class ProductCategoryResponseModel : BaseResponse
    {
        public ProductCategoryDTOs Data { get; set; }
    }

    public class CreateProductCategoryRequestModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
    }

    public class UpdateProductCategoryRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
    }
}
