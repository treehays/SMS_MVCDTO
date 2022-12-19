using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Service
{
    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendant;
        private readonly IUserRepository _userRepository;
        public AttendantService(IAttendantRepository attendantRepository, IUserRepository userRepository)
        {
            _attendant = attendantRepository;
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
            _attendant.Create(attend);

            return attendant;
        }

        public void Delete(string staffId)
        {
            var attendant = _attendant.GetById(staffId);
            //if (attendant == null)
            //{

            //}
            _attendant.Delete(attendant);
        }

        public IList<Attendant> GetAttendants()
        {
            var attendants = _attendant.GetAttendants();
            return attendants;
        }

        public Attendant GetByEmail(string email)
        {
            var attendant = _attendant.GetByEmail(email);
            return attendant;
        }

        public Attendant GetById(string staffId)
        {
            var attendant = _attendant.GetById(staffId);
            return attendant;
        }

        public IList<Attendant> GetByName(string name)
        {
            var attendants = _attendant.GetByName(name);
            return attendants;
        }

        public Attendant GetByPhoneNumber(string phoneNumber)
        {
            var attendant = _attendant.GetByPhoneNumber(phoneNumber);
            return attendant;
        }

        //public User Login(LoginRequestModel user)
        //{
        //    var userD = new User
        //    {
        //        StaffId = user.StaffId,
        //        Password = user.Password
        //    };
        //    var users = _userRepository.Login(userD);
        //    return users;

        //}

        public UpdateAttendantRequestModel Update(UpdateAttendantRequestModel attendant)
        {
            var attendan = _attendant.GetById(attendant.StaffId);
            if (attendan == null)
            {
                return null;
            }
            attendan.FirstName = attendant.FirstName ?? attendan.FirstName;
            attendan.LastName = attendant.LastName ?? attendan.LastName;
            attendan.ResidentialAddress = attendant.ResidentialAddress ?? attendan.ResidentialAddress;
            attendan.MaritalStatus = attendant.MaritalStatus;
            attendan.BankName = attendant.BankName ?? attendan.BankName;
            attendan.BankAccountNumber = attendant.BankAccountNumber ?? attendan.BankAccountNumber;
            attendan.Modified = DateTime.Now;
            _attendant.Update(attendan);
            return attendant;
        }

        public UpdateAttendantPasswordRequestModel UpdatePassword(UpdateAttendantPasswordRequestModel attendant)
        {
            var user = _userRepository.GetById(attendant.StaffId);
            if (user == null)
            {
                return null;
            }
            user.Password = attendant.Password ?? user.Password;
            _userRepository.UpdatePassword(user);
            return attendant;
        }

        public UpdateAttendantRoleRequestModel UpdateRole(UpdateAttendantRoleRequestModel attendant)
        {

            var user = _userRepository.GetById(attendant.StaffId);
            if (user == null)
            {
                return null;
            }
            user.Role = attendant.UserRole;
            _userRepository.UpdateRole(user);
            return attendant;
        }
    }


}

