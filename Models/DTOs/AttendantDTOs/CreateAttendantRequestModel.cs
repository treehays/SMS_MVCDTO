using SMS_MVCDTO.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.AttendantDTOs
{
    public class CreateAttendantRequestModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Valid password")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Re-Enter Password")]
        [Compare("Password", ErrorMessage = "Password not Match")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Phone No.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }
        [DisplayName("Residential Address")]
        public string ResidentialAddress { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        [DisplayName("Home Address")]
        public MaritalStatusType MaritalStatus { get; set; }
        [DisplayName("Marital Status")]
        public string BankAccountNumber { get; set; }
        [DisplayName("Bank Account Number")]
        public string BankName { get; set; }
        [DisplayName("Bank Name")]
        public string GuarantorName { get; set; }
        [DisplayName("Guarantor Name")]
        public string GuarantorPhoneNumber { get; set; }
        //public UserRoleType userRole { get; set; }
    }

}
