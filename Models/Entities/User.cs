
namespace SMS_MVCDTO.Models.Entities
{
    //[Index(nameof(StaffId), IsUnique = true)]
    public class User : BaseEntity
    {

        public Role Role { get; set; }
        public SuperAdmin SuperAdmin { get; set; }
        public SalesManager SalesManager { get; set; }
        public Attendant Attendant { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public BankDetail BankDetail { get; set; }
        public int RoleId { get; set; }


        public string Password { get; set; }
        public string PasswordResetToken { get; set; }
        public string StaffId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public byte[] ProfilePicture { get; set; }



        public static string GenerateRandomId(string secondLetter)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            var r1 = new Random().Next(25);
            var r2 = new Random().Next(25);
            var staffId = $"{secondLetter}{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000);
            return staffId;
        }
    }
}
