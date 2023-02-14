using SMS_MVCDTO.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.CustomerDTOs
{
    public class CreateCustomerRequestModel
    {
        [Required(ErrorMessage = "Name can't be empty")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Name can't be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Valid Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }


        //@*Rexmove*@ 


        [Required(ErrorMessage = "Enter Valid password")]
        [DisplayName("Password")]
        public string Password { get; set; }
        //@*Rexmove*@ 

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "pass ")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Marital Status")]
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
