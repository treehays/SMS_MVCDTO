namespace SMS_MVCDTO.Models.Entities
{
    public class Wallet : BaseEntity
    {
        //public String Id { get; set; }
        public User Users { get; set; }
        public string UserId { get; set; }
    }
}
