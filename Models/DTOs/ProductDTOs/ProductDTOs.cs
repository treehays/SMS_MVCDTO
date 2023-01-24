using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class ProductDTOs
    {
        [Required]
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
