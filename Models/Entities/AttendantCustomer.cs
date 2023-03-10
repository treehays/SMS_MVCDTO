using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    public class AttendantCustomer : BaseEntity
    {
        [ForeignKey("Attendant")]
        public string AttendantId { get; set; }
        public Attendant Attendant { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
