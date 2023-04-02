using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    public class Customer : BaseEntity
    {
        public ICollection<AttendantCustomer> AttendantCustomers { get; set; } = new HashSet<AttendantCustomer>();
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
        public User User { get; set; }
        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public GenderType Gender { get; set; }
        //public Address Address { get; set; }


        //public string FirstName { get; set; }
        //public string LastName { get; set; }

    }
}
