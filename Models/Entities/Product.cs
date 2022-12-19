using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.Entities
{
    [Index(nameof(Barcode), IsUnique = true)]
    public class Product : BaseEntity
    {
        public IList<ProductCategoryProduct> ProductCategoryProducts { get; set; }
        public IList<ProductCategory> productCategories { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        [Required]
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }

    }
}