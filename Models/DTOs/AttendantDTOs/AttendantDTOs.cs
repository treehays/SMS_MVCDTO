using SMS_MVCDTO.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.AttendantDTOs
{
    public class AttendantDTOs
    {
        public string StaffId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public GenderType Gender { get; set; }
        public string LastName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        [DisplayName("Address")]
        public string ResidentialAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Status")]
        public MaritalStatusType MaritalStatus { get; set; }
        [DisplayName("Acct. number")]
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string GuarantorName { get; set; }
        [DisplayName("Ref. Name")]
        public string GuarantorPhoneNumber { get; set; }
        public UserRoleType UserRole { get; set; }
    }
}
