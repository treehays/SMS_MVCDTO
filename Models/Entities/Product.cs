

namespace SMS_MVCDTO.Models.Entities
{
    //[Index(nameof(Barcode), IsUnique = true)]
    public class Product : BaseEntity
    {
        public string ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Cart Cart { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public double Quantity { get; set; }
        public double ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }
        public string PicturPath { get; set; }

    }
}