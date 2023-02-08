using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SMS_MVCDTO.Models.DTOs.SuperAdminDTOs
{
    public class CreateSuperAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string ResidentialAddress { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
        public UserRoleType userRole { get; set; }
    }

}
