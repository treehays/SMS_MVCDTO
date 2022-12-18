﻿namespace SMS_MVCDTO.Models.Entities
{
    public class Transaction : BaseEntity
    {
        //public string ProductId { get; set; }
        public IList<ProductTransaction> ProductTransactions { get; set; }
        public Wallet Wallets { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
    }
}
