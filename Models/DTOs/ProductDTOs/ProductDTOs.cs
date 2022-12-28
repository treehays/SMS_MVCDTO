using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.DTOs.ProductDTOs
{
    public class ProductDTOs
    {
        [Required]
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class ProductResponseModel : BaseResponse
    {
        public ProductDTOs Data { get; set; }
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
