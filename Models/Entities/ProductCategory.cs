namespace SMS_MVCDTO.Models.Entities
{
    public class ProductCategory : BaseEntity
    {
        public IList<Product> Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
