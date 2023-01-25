using SMS_MVCDTO.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.CustomerDTOs
{
    public class CreateCustomerRequestModel
    {
        [Required(ErrorMessage = "Name sholu valid")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Valid password")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Valid password")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "pass not match")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
    }

    //public class LoginRequestModel
    //{
    //    [Required]
    //    public string StaffId { get; set; }
    //    [Required]
    //    public string Password { get; set; }
    //}
}
