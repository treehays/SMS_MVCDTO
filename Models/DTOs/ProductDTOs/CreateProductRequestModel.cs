using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class CreateProductRequestModel
    {
        //public IList<ProductCategoryResponseModel> Categories { get; set; }
        //public String  Category { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        [DisplayName("Selling Price")]
        [RegularExpression(@"^([1-9][0-9]{0,5}|1000000)(\.\d{1,2})?$", ErrorMessage = "Selling Price should should be numbers.")]
        public double SellingPrice { get; set; }

        [DisplayName("Quantity")]
        [RegularExpression(@"^([1-9][0-9]{0,5}|1000000)$", ErrorMessage = "Quantity should should contain only numbers.")]
        public double Quantity { get; set; }

        [RegularExpression(@"^([1-9][0-9]{0,5}|1000000)$", ErrorMessage = "Reorder level should should contain only numbers.")]
        [DisplayName("Reorder Point")]
        public double ReorderLevel { get; set; }
    }

}
