﻿using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_MVCDTO.Models.Entities
{
    //[Index(nameof(Email), IsUnique = true)]
    //[Index(nameof(PhoneNumber), IsUnique = true)]
    public class SalesManager : BaseEntity
    {
        public ICollection<Attendant> Attendants { get; set; }
        public User User { get; set; }
        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
        //public Address Address { get; set; }
        // public BankDetail BankDetail { get; set; }


        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
        public string CVPath { get; set; }
    }
}
