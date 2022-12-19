﻿using SMS_MVCDTO.Enums;

namespace SMS_MVCDTO.Models.Entities
{
    public class SuperAdmin : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public UserRoleType userRole { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
        //public IList<Transaction> Transactions { get; set; }
        //public Wallet Wallets { get; set; }
        /*
         parent,upload photo, upload proof of residence, valid id card
         */
    }
}
