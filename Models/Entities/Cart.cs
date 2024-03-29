﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    public class Cart : BaseEntity
    {
        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        //[ForeignKey("Product")]

        public string ProductId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        //[ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }
        //[ForeignKey(nameof(Transaction))]
        public string TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        //public double Price { get; set; }

    }
}
