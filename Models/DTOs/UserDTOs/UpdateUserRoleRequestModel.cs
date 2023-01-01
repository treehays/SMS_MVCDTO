using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.Models.DTOs.UserDTOs
{
    public class UpdateUserRoleRequestModel
    {
        public UserRoleType Role { get; set; }
        public string StaffId { get; set; }
    }
}
