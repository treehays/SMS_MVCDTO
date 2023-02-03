using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;
using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.Entities;
using System.ComponentModel;

namespace SMS_MVCDTO.Models.ViewModels
{
    public class NewProductViewModel
    {
        //public int Id { get; set; }
        [DisplayName("Product Category")]
        public IList<ProductCategoryResponseModel> PCategory { get; set; }
        //[DisplayName("")]
        public CreateProductRequestModel CreateProduct { get; set; }
        public ProductResponseModel UpdateProduct { get; set; }
    }
}
