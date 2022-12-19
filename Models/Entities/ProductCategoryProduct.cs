namespace SMS_MVCDTO.Models.Entities
{
    public class ProductCategoryProduct : BaseEntity
    {
        public Product Products { get; set; }
        public int ProductsId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
