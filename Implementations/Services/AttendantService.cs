using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.AttendantDTOs;
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

        //Done

        public CreateAttendantRequestModel Create(CreateAttendantRequestModel attendant)
        {
            var sid = User.GenerateRandomId("T");
            var user = new User
            {
                StaffId = sid,
                Password = attendant.Password,
                Role = UserRoleType.Attendant,
                Created = DateTime.Now

            };
            var isdd = _userRepository.Create(user);

            var attend = new Attendant
            {
                StaffId = sid,
                Email = attendant.Email,
                FirstName = attendant.FirstName,
                LastName = attendant.LastName,
                PhoneNumber = attendant.PhoneNumber,
                HomeAddress = attendant.HomeAddress,
                ResidentialAddress = attendant.ResidentialAddress,
                IsActive = true,
                DateOfBirth = attendant.DateOfBirth,
                Gender = attendant.Gender,
                MaritalStatus = attendant.MaritalStatus,
                userRole = UserRoleType.Attendant,
                BankAccountNumber = attendant.BankAccountNumber,
                BankName = attendant.BankName,
                GuarantorName = attendant.GuarantorName,
                GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                Created = DateTime.Now,
                UserId = sid
            };
            _attendant.Create(attend);

            return attendant;
        }

        public void Delete(string staffId)
        {
            var attendant = _attendant.GetById(staffId);
            if (attendant != null)
            {
                _attendant.Delete(attendant);
            }

        }

        public IEnumerable<AttendantResponseModel> GetAttendants()
        {
            var attendants = _attendant.GetAttendants();
            if (attendants == null)
            {
                return null;
            }
            var attendantResponseModels = attendants.Select(item => new AttendantResponseModel
            {
                Message = "Attendant retrieved Successfully",
                Status = true,
                Data = new AttendantDTOs
                {
                    BankAccountNumber = item.BankAccountNumber,
                    GuarantorName = item.GuarantorName,
                    BankName = item.BankName,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    Gender = item.Gender,
                    LastName = item.LastName,
                    GuarantorPhoneNumber = item.GuarantorPhoneNumber,
                    HomeAddress = item.HomeAddress,
                    MaritalStatus = item.MaritalStatus,
                    PhoneNumber = item.PhoneNumber,
                    ResidentialAddress = item.ResidentialAddress,
                    StaffId = item.StaffId,
                    UserRole = item.userRole,
                }
            }).ToList();
            return attendantResponseModels;

        }


        public AttendantResponseModel GetByEmail(string email)
        {

            var attendant = _attendant.GetByEmail(email);
            if (attendant != null)
            {

                var attendantResponseModel = new AttendantResponseModel
                {
                    Message = "Attendant retrieved Successfully",
                    Status = true,
                    Data = new AttendantDTOs
                    {
                        BankAccountNumber = attendant.BankAccountNumber,
                        GuarantorName = attendant.GuarantorName,
                        BankName = attendant.BankName,
                        DateOfBirth = attendant.DateOfBirth,
                        Email = attendant.Email,
                        FirstName = attendant.FirstName,
                        Gender = attendant.Gender,
                        LastName = attendant.LastName,
                        GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                        HomeAddress = attendant.HomeAddress,
                        MaritalStatus = attendant.MaritalStatus,
                        PhoneNumber = attendant.PhoneNumber,
                        ResidentialAddress = attendant.ResidentialAddress,
                        StaffId = attendant.StaffId,
                        UserRole = attendant.userRole,
                    }
                };
                return attendantResponseModel;
            }
            return null;
        }

        public AttendantResponseModel GetById(string staffId)
        {
            var attendant = _attendant.GetById(staffId);
            if (attendant != null)
            {
                var attendantResponseModel = new AttendantResponseModel
                {
                    Message = "Attendant retrieved Successfully",
                    Status = true,
                    Data = new AttendantDTOs
                    {
                        BankAccountNumber = attendant.BankAccountNumber,
                        GuarantorName = attendant.GuarantorName,
                        BankName = attendant.BankName,
                        DateOfBirth = attendant.DateOfBirth,
                        Email = attendant.Email,
                        FirstName = attendant.FirstName,
                        Gender = attendant.Gender,
                        LastName = attendant.LastName,
                        GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                        HomeAddress = attendant.HomeAddress,
                        MaritalStatus = attendant.MaritalStatus,
                        PhoneNumber = attendant.PhoneNumber,
                        ResidentialAddress = attendant.ResidentialAddress,
                        StaffId = attendant.StaffId,
                        UserRole = attendant.userRole,
                    }
                };
                return attendantResponseModel;
            }
            return null;
        }

        public IEnumerable<AttendantResponseModel> GetByName(string name)
        {
            var attendants = _attendant.GetByName(name);
            if (attendants == null)
            {
                return null;
            }
            var attendantResponseModels = attendants.Select(item => new AttendantResponseModel
            {
                Message = "Attendant retrieved Successfully",
                Status = true,
                Data = new AttendantDTOs
                {
                    BankAccountNumber = item.BankAccountNumber,
                    GuarantorName = item.GuarantorName,
                    BankName = item.BankName,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    Gender = item.Gender,
                    LastName = item.LastName,
                    GuarantorPhoneNumber = item.GuarantorPhoneNumber,
                    HomeAddress = item.HomeAddress,
                    MaritalStatus = item.MaritalStatus,
                    PhoneNumber = item.PhoneNumber,
                    ResidentialAddress = item.ResidentialAddress,
                    StaffId = item.StaffId,
                    UserRole = item.userRole,
                }
            }).ToList();
            return attendantResponseModels;
        }

        public AttendantResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var attendant = _attendant.GetByPhoneNumber(phoneNumber);
            var attendantResponseModel = new AttendantResponseModel
            {
                Message = "Attendant retrieved Successfully",
                Status = true,
                Data = new AttendantDTOs
                {
                    BankAccountNumber = attendant.BankAccountNumber,
                    GuarantorName = attendant.GuarantorName,
                    BankName = attendant.BankName,
                    DateOfBirth = attendant.DateOfBirth,
                    Email = attendant.Email,
                    FirstName = attendant.FirstName,
                    Gender = attendant.Gender,
                    LastName = attendant.LastName,
                    GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                    HomeAddress = attendant.HomeAddress,
                    MaritalStatus = attendant.MaritalStatus,
                    PhoneNumber = attendant.PhoneNumber,
                    ResidentialAddress = attendant.ResidentialAddress,
                    StaffId = attendant.StaffId,
                    UserRole = attendant.userRole,
                }

            };

            return attendantResponseModel;
        }


        public AttendantResponseModel Update(AttendantResponseModel attendant)
        {
            var attendan = _attendant.GetById(attendant.Data.StaffId);
            if (attendan == null)
            {
                return null;
            }

            attendan.FirstName = attendant.Data.FirstName ?? attendan.FirstName;
            attendan.LastName = attendant.Data.LastName ?? attendan.LastName;
            attendan.ResidentialAddress = attendant.Data.ResidentialAddress ?? attendan.ResidentialAddress;
            attendan.MaritalStatus = attendant.Data.MaritalStatus;
            attendan.BankName = attendant.Data.BankName ?? attendan.BankName;
            attendan.BankAccountNumber = attendant.Data.BankAccountNumber ?? attendan.BankAccountNumber;
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
    }
}

