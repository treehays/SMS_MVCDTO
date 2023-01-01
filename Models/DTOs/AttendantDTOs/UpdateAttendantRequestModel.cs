using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.Models.DTOs.AttendantDTOs
{
    public class UpdateAttendantRequestModel
    {
        public string StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        public string ResidentialAddress { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
    }
}
