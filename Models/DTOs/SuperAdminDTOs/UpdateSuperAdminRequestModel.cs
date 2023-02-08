using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.Models.DTOs.SuperAdminDTOs
{
    public class UpdateSuperAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pin { get; set; }
        public string ResidentialAddress { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string StaffId { get; set; }
    }

}
