using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.Models.DTOs.CustomerDTOs
{
    public class UpdateCustomerRequestModel
    {
		public string StaffId { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
    }

    
}
