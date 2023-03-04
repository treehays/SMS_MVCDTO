using SMS_MVCDTO.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.SalesManagerDTOs
{
    public class CreateSalesManagerRequestModel
    {
        [Required(ErrorMessage = "First Name can't be empty")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = " Last Name can't be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Valid Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Valid password")]
        [DisplayName("Password")]
        public string Password { get; set; }
        //@*Rexmove*@ 

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Paasword not matched. ")]
        public string ConfirmPassword { get; set; }
        [DisplayName("phone Number")]
        public string PhoneNumber { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        [DisplayName("Marital Status")]
        public MaritalStatusType MaritalStatus { get; set; }
        [DisplayName("Bank Account Number")]
        public string BankAccountNumber { get; set; }
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
        public string AccountType { get; set; }
        [DisplayName("Guarantor Name")]
        public string GuarantorName { get; set; }
        [DisplayName("Guarantor Phone Number")]
        public string GuarantorPhoneNumber { get; set; }
        //public IFormFile Document { get; set; }
        [DisplayName("Street Name")]
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [DisplayName("Profile picture")]
        public byte[] ProfilePicture { get; set; }
        public string CVPath { get; set; }

    }


}
