namespace SMS_MVCDTO.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Barcode { get; set; }
        public string TransactionId { get; set; }
        public IList<ProductTransaction> ProductTransactions { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IdAvailable { get; set; }

    }
}