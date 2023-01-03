using System.ComponentModel;

namespace SMS_MVCDTO.Models.DTOs.ProductDTOs
{
    public class UpdateProductRequestModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public string Category { get; set; }
        //public int Quantity { get; set; }
        public double ReorderLevel { get; set; }
    }

}
