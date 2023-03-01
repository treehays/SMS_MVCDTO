using SMS_MVCDTO.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.AttendantDTOs
{
	public class CreateAttendantRequestModel
	{
		//  [Required(ErrorMessage = "First Name can't be empty")]
		[DisplayName("First Name")]
		public string FirstName { get; set; }
		[DisplayName("Last Name")]
		//  [Required(ErrorMessage = "Last Name can't be empty")]
		public string LastName { get; set; }
		//  [Required(ErrorMessage = "Enter a Valid Email")]
		[EmailAddress(ErrorMessage = "Enter a Valid Email")]
		public string Email { get; set; }

		//  [Required(ErrorMessage = "Password can't be empty")]
		[DisplayName("Password")]
		public string Password { get; set; }
		// [Required]
		[DisplayName("Re-enter Password")]
		[Compare("Password", ErrorMessage = "Password not match ")]
		public string ConfirmPassword { get; set; }
		//  [Required(ErrorMessage = "Phone number is required")]
		[DisplayName("Phone number")]

		public string PhoneNumber { get; set; }
		[DisplayName("Address Name")]
		public string AddressName { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		[DisplayName("Date of Birth")]
		public DateTime DateOfBirth { get; set; }
		// [Required(ErrorMessage = "Gender can't be empty")]
		[DisplayName("Gender")]

		public GenderType Gender { get; set; }
		//    [Required(ErrorMessage = "Pick a Marital Status")]
		[DisplayName("Marital Status")]
		public MaritalStatusType MaritalStatus { get; set; }
		// [Required(ErrorMessage = "account detailscan't be empty")]
		[DisplayName("Bank Account Number")]
		public string BankAccountNumber { get; set; }
		[DisplayName("Bank Name")]
		public string BankName { get; set; }
		// [Required(ErrorMessage = "Guarantor is required")]
		[DisplayName("Guarantor Name")]
		public string GuarantorName { get; set; }
		//[Required(ErrorMessage = "Guarantor is required")]
		[DisplayName("Guarantor PhoneNumber")]
		public string GuarantorPhoneNumber { get; set; }
		/*
         public UserRoleType userRole { get; set; }*/
		// [Required(ErrorMessage = "Password can't be empty")]
		[DisplayName("Profile picture")]

		public byte[] ProfilePicture { get; set; }
		// [Required(ErrorMessage = " ")]
		[DisplayName("Street name")]

		public string StreetName { get; set; }
		// [Required(ErrorMessage = " ")]
		[DisplayName("City")]
		public string City { get; set; }
		// [Required(ErrorMessage = " ")]
		[DisplayName("state")]
		public string State { get; set; }
		// [Required(ErrorMessage = " ")]
		[DisplayName("postal code")]
		public string PostalCode { get; set; }
		//[Required(ErrorMessage = "")]
		[DisplayName("country of origin")]
		public string Country { get; set; }
		public string CVPath { get; set; }


	}

}
