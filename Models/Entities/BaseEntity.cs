namespace SMS_MVCDTO.Models.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
