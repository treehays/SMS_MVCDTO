using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.SalesManagerDTOs
{
    public class SalesManagerDTOs
    {
        public string StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
        public UserRoleType userRole { get; set; }
    }

    //public class LoginRequestModel
    //{
    //    [Required]
    //    [Required]
    //    public string Password { get; set; }
    //}
}
