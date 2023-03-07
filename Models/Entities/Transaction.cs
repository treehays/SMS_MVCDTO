using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public Attendant Attendant { get; set; }
        public string AttendantId { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public string ReferenceNo { get; set; }
        public double AmountPaid { get; set; }
        public double TotalAmount { get; set; }

    }
}
