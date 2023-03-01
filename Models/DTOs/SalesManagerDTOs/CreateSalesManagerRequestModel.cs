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
		[Compare("Password", ErrorMessage = "pass ")]
		public string ConfirmPassword { get; set; }
		[DisplayName("phone nymber")]
		public string PhoneNumber { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		[DisplayName("Date of Birth")]
		public DateTime DateOfBirth { get; set; }
		public GenderType Gender { get; set; }
		[DisplayName("Marital Status")]
		public MaritalStatusType MaritalStatus { get; set; }
		[DisplayName("Bank Account Number")]
		public string BankAccountNumber { get; set; }
		[DisplayName("Bank Name")]
		public string BankName { get; set; }
		[DisplayName("Guarantor Name")]
		public string AccountType { get; set; }
		public string GuarantorName { get; set; }
		[DisplayName("Guarantor Phone Number")]
		public string GuarantorPhoneNumber { get; set; }
		public IFormFile Document { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public byte[]? ProfilePicture { get; set; }
	}


}
