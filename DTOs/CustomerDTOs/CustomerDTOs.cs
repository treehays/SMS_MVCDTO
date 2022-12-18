using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.DTOs.CustomerDTOs
{
    public class CustomerDTOs
    {

    }

    public class CreateCustomerRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
    }

    public class UpdateCustomerRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
    }

    public class UpdateCustomerPasswordRequestModel
    {
        public string Pin { get; set; }
    }

    public class LoginRequestModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
