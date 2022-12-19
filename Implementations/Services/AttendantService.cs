using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;

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
            var attendant = _attendantRepository.GetById(staffId);
            //if (attendant == null)
            //{

            //}
            _attendantRepository.Delete(attendant);
        }

        public IList<Attendant> GetAttendants()
        {
            var attendants = _attendantRepository.GetAttendants();
            return attendants;
        }

        public Attendant GetByEmail(string email)
        {
            var attendant = _attendantRepository.GetByEmail(email);
            return attendant;
        }

        public Attendant GetById(string staffId)
        {
            var attendant = _attendantRepository.GetById(staffId);
            return attendant;
        }

        public IList<Attendant> GetByName(string name)
        {
            var attendants = _attendantRepository.GetByName(name);
            return attendants;
        }

        public Attendant GetByPhoneNumber(string phoneNumber)
        {
            var attendant = _attendantRepository.GetByPhoneNumber(phoneNumber);
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
            var attendan = _attendantRepository.GetById(attendant.StaffId);
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
            _attendantRepository.Update(attendan);
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

