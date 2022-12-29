using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.Entities
{
    public class ProductCategory : BaseEntity
    {
        //public IList<ProductCategoryProduct> ProductCategoryProducts { get; set; }
        public IList<Product> Products { get; set; }
        [Key]
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}

