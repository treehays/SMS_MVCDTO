using SMS_MVCDTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Models.DTOs.SalesManagerDTOs
{
    public class SalesManagerDTOs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorPhoneNumber { get; set; }
        public string StaffId { get; set; }
        public string CVPath { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }



    }


}
