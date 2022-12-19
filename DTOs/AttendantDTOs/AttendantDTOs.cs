using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.DTOs.AttendantDTOs
{
    public class AttendantDTOs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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

    public class CreateAttendantRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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


    public class UpdateAttendantPasswordRequestModel
    {
        public string Password { get; set; }
    }
    public class UpdateAttendantRoleRequestModel
    {
        public UserRoleType UserRole { get; set; }
    }


    public class UpdateAttendantRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ResidentialAddress { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
    }

}
