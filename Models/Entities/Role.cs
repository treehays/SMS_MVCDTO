namespace SMS_MVCDTO.Models.Entities
{
    public class Role : BaseEntity
    {
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

    }
}
