namespace SMS_MVCDTO.DTOs.ProductCategoriesDTOs
{
    public class ProductCategoryDTOs
    {
    }

    public class CreateProductCategoryRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateProductCategoryRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
