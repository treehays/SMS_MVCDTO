using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.UserDTOs
{
    public class LoginRequestModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
