using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.DTOs.CustomerDTOs;
using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCDTO.Implementations.Service
{
    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendantRepository;
        private readonly IUserRepository _userRepository;
        public AttendantService(IAttendantRepository attendantRepository, IUserRepository userRepository)
        {
            _attendantRepository = attendantRepository;
            _userRepository = userRepository;
        }

        public CreateAttendantRequestModel Create(CreateAttendantRequestModel attendant)
        {
            var sid = User.GenerateRandomId("T");
            var user = new User
            {
                StaffId = sid,
                Password = attendant.Password,
                Role = UserRoleType.Attendant

            };
            _userRepository.Create(user);

            var attend = new Attendant
            {
                StaffId = sid,
                Email = attendant.Email,
                PhoneNumber = attendant.PhoneNumber,
                HomeAddress = attendant.HomeAddress,
                ResidentialAddress = attendant.ResidentialAddress,
                IsActive = true,
                DateOfBirth = attendant.DateOfBirth,
                Gender = attendant.Gender,
                MaritalStatus = attendant.MaritalStatus,
                userRole = attendant.userRole,
                BankAccountNumber = attendant.BankAccountNumber,
                BankName = attendant.BankName,
                GuarantorName = attendant.GuarantorName,
                GuarantorPhoneNumber = attendant.GuarantorPhoneNumber
            };
            _attendantRepository.Create(attend);

            return attendant;
        }

        public void Delete(string staffId)
        {
            throw new NotImplementedException();
        }

        public IList<Attendant> GetAttendants()
        {
            throw new NotImplementedException();
        }

        public Attendant GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Attendant GetById(string staffId)
        {
            throw new NotImplementedException();
        }

        public IList<Attendant> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Attendant GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public LoginRequestModel Login(LoginRequestModel user)
        {
            throw new NotImplementedException();
        }

        public UpdateAttendantRequestModel Update(UpdateAttendantRequestModel attendant)
        {
            throw new NotImplementedException();
        }

        public UpdateAttendantPasswordRequestModel UpdatePassword(UpdateAttendantPasswordRequestModel attendant)
        {
            throw new NotImplementedException();
        }

        public UpdateAttendantRoleRequestModel UpdateRole(UpdateAttendantRoleRequestModel attendant)
        {
            throw new NotImplementedException();
        }


    }
}
