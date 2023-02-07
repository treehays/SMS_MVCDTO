namespace SMS_MVCDTO.Models.DTOs.UserDTOs
{
    public class UpdateUserPasswordRequestModel
    {
        public string Password { get; set; }
        public string StaffId { get; set; }
        public byte[]? ProfilePicture { get; set; }

    }
}
