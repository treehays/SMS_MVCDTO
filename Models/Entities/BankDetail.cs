using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    public class BankDetail : BaseEntity
    {
        // public Attendant Attendant { get; set; }
        //  public int AttendantId { get; set; }
        // public SalesManager SalesManager { get; set; }
        //public int SalesManagerId { get; set; }
        //public SuperAdmin SuperAdmin { get; set; }
        // public int SuperAdminId { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
    }
}
