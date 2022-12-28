using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.DTOs.SuperAdminDTOs
{

    public class SuperAdminDTOs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
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

    public class SuperAdminResponseModel : BaseResponse
    {
        public SuperAdminDTOs Data { get; set; }
    }
    public class CreateSuperAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
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


    public class UpdateSuperAdminPasswordRequestModel
    {
        public string Pin { get; set; }
    }


    public class UpdateSuperAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pin { get; set; }
        public string ResidentialAddress { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
    }

}
