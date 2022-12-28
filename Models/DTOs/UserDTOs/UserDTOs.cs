﻿using SMS_MVCDTO.Enums;
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
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Pin { get; set; }
        //public string PhoneNumber { get; set; }
        //public string HomeAddress { get; set; }
        //public string ResidentialAddress { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public GenderType Gender { get; set; }
        //public MaritalStatusType MaritalStatus { get; set; }
        //public string BankAccountNumber { get; set; }
        //public string BankName { get; set; }
        //public string GuarantorName { get; set; }
        //public string GuarantorPhoneNumber { get; set; }
        //public UserRoleType userRole { get; set; }
    }


    public class UpdateUserPasswordRequestModel
    {
        public string Password { get; set; }
        public string StaffId { get; set; }
    }


    //public class UpdateUserRequestModel
    //{
    //    //public string FirstName { get; set; }
    //    //public string LastName { get; set; }
    //    //public string Pin { get; set; }
    //    //public string ResidentialAddress { get; set; }
    //    //public MaritalStatusType MaritalStatus { get; set; }
    //    //public string BankAccountNumber { get; set; }
    //    //public string BankName { get; set; }
    //}

    public class LoginRequestModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
