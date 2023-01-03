using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.CustomerDTOs
{
    public class CustomerDTOs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public UserRoleType UserRole { get; set; }
    }

    //public class LoginRequestModel
    //{
    //    [Required]
    //    public string StaffId { get; set; }
    //    [Required]
    //    public string Password { get; set; }
    //}
}
