using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.DTOs.AttendantDTOs
{
    public class UpdateAttendantRoleRequestModel
    {
        public string StaffId { get; set; }
        public UserRoleType UserRole { get; set; }
    }

}
