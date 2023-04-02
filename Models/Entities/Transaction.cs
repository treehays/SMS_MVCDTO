using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public Customer Customer { get; set; }
        //[ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }
        public Attendant Attendant { get; set; }
        //[ForeignKey(nameof(Attendant))]
        public string AttendantId { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public string ReferenceNo { get; set; }
        public double AmountPaid { get; set; }
        public double TotalAmount { get; set; }

    }
}
