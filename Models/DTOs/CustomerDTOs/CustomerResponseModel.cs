namespace SMS_MVCDTO.Models.DTOs.CustomerDTOs
{
    public class CustomerResponseModel : BaseResponse
    {
        public CustomerDTOs Data { get; set; }
    }

    //public class LoginRequestModel
    //{
    //    [Required]
    //    public string StaffId { get; set; }
    //    [Required]
    //    public string Password { get; set; }
    //}
}
