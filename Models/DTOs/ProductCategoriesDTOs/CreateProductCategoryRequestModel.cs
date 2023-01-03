using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs
{
    public class CreateProductCategoryRequestModel
    {
        [Required(ErrorMessage ="Category must have a name")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Category Name")]
        [Compare("Name",ErrorMessage ="Confirm Category name")]
        public string ConfirmName { get; set; }
        [Required(ErrorMessage ="Can not be empty")]
        public string Description { get; set; }

    }
}
