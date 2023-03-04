using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.UserDTOs
{
	public class UserDTOs
	{
		[Required]
		public string StaffId { get; set; }
		[Required]
		public string Password { get; set; }
		public int RoleId { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Name { get; set; }
		public byte[] ProfilePicture { get; set; }


	}
}
