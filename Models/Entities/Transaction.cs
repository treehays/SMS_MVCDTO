using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        //public IList<Product> Products { get; set; }
        public string AttendantId { get; set; }
        public string ProductId { get; set; }
        public Attendant Attendant { get; set; }
        [Key]
        public string ReferenceNo { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        //public string ProductId { get; set; }
        //public string AttendantId { get; set; }
        //public Attendant Attendant { get; set; }
        //public Wallet Wallets { get; set; }

    }
}
