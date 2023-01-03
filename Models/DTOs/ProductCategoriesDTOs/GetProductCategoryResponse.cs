using System.ComponentModel;

namespace SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs
{
    public class GetProductCategoryResponse
    {
        [DisplayName("Category Name")]
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
