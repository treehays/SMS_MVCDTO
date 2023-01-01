using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.UserDTOs
{
    public class CreateUserRequestModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRoleType Role { get; set; }
    }
}
