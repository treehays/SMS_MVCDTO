namespace SMS_MVCDTO.Models.Entities
{
    public class Product : BaseEntity
    {
        //public string TransactionId { get; set; }
        public IList<ProductTransaction> ProductTransactions { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }

    }
}