using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.DTOs.UserDTOs
{
    public class UserDTOs
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRoleType Role { get; set; }
    }

    public class UserResponseModel : BaseResponse
    {
        public UserDTOs Data { get; set; }
    }

    public class CreateUserRequestModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRoleType Role { get; set; }
    }


    public class UpdateUserPasswordRequestModel
    {
        public string Password { get; set; }
        public string StaffId { get; set; }
    }

    public class UpdateUserRoleRequestModel
    {
        public UserRoleType Role { get; set; }
        public string StaffId { get; set; }
    }

    public class LoginRequestModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
