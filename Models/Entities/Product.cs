using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.Entities
{
    //[Index(nameof(Barcode), IsUnique = true)]
    public class Product : BaseEntity
    {
        //public int Id { get; set; }
        //public IList<ProductCategoryProduct> ProductCategoryProducts { get; set; }
        //public IList<ProductCategory> productCategories { get; set; }
        public string ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        //public int TransactionId { get; set; }
        //public Transaction Transaction { get; set; }
        [Required]
        [Key]
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public double Quantity { get; set; }
        public double ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }

    }
}