using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;
using System.Net.Http.Headers;

namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class CreateProductRequestModel
    {
        //public IList<ProductCategoryResponseModel> Categories { get; set; }
        //public String  Category { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public double Quantity { get; set; }
        public double ReorderLevel { get; set; }
    }

}
