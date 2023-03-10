using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.AttendantDTOs;
using SMS_MVCDTO.Models.Entities;
using System.Security.Claims;

namespace SMS_MVCDTO.Implementations.Service
{
    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IBankDetailRepository _bankDetailRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AttendantService(IAttendantRepository attendantRepository, IUserRepository userRepository, IAddressRepository addressRepository, IBankDetailRepository bankDetailRepository, IHttpContextAccessor httpContextAccessor)
        {
            _attendantRepository = attendantRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _bankDetailRepository = bankDetailRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        //Done

        public CreateAttendantRequestModel Create(CreateAttendantRequestModel attendant)
        {
            var sid = User.GenerateRandomId("T");
            var user = new User
            {
                StaffId = sid,
                FirstName = attendant.FirstName,
                LastName = attendant.LastName,
                Password = attendant.Password,
                RoleId = "3",
                Created = DateTime.Now,
                ProfilePicture = attendant.ProfilePicture,
                Email = attendant.Email,
                PhoneNumber = attendant.PhoneNumber,
                IsActive = true,

                //FirstName = attendant.FirstName,
                //LastName = attendant.LastName,

            };
            _userRepository.Create(user);
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value;
            //int a = int.Parse(id);
            var attend = new Attendant
            {
                UserId = user.Id,
                //SalesManagerID = "1",
                //SalesManagerID = id,
                DateOfBirth = attendant.DateOfBirth,
                Gender = attendant.Gender,
                GuarantorName = attendant.GuarantorName,
                GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                Created = DateTime.Now,
                MaritalStatus = attendant.MaritalStatus,
                CVPath = attendant.CVPath,
            };
            _attendantRepository.Create(attend);


            var address = new Address
            {
                UserId = user.Id,
                StreetName = attendant.StreetName,
                City = attendant.City,
                PostalCode = attendant.PostalCode,
                State = attendant.State,
                Country = attendant.Country,
            };
            _addressRepository.Create(address);

            var bankDetail = new BankDetail
            {
                UserId = user.Id,
                BankAccountNumber = attendant.BankAccountNumber,
                BankName = attendant.BankName,
            };
            _bankDetailRepository.Create(bankDetail);

            return attendant;
        }

        public void Delete(string id)
        {
            var attendant = _attendantRepository.GetById(id);
            if (attendant != null)
            {
                attendant.IsDeleted = true;
                _attendantRepository.Delete(attendant);
            }

        }

        public IEnumerable<AttendantResponseModel> GetAttendants()
        {
            var attendants = _attendantRepository.GetAttendants();
            if (attendants == null)
            {
                return null;
            }
            var attendantResponseModels = attendants.Select(attendant => new AttendantResponseModel
            {
                Message = "Attendant retrieved Successfully",
                Status = true,
                Data = new AttendantDTOs
                {
                    BankAccountNumber = attendant.User.BankDetail == null ? null : attendant.User.BankDetail.BankAccountNumber,
                    BankName = attendant.User.BankDetail == null ? null : attendant.User.BankDetail.BankName,
                    GuarantorName = attendant.GuarantorName,
                    DateOfBirth = attendant.DateOfBirth,
                    Email = attendant.User.Email,
                    FirstName = attendant.User.FirstName,
                    Gender = attendant.Gender,
                    LastName = attendant.User.LastName,
                    GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                    MaritalStatus = attendant.MaritalStatus,
                    PhoneNumber = attendant.User.PhoneNumber,
                    //ResidentialAddress = $"{attendant.User.Address.StreetName}, {attendant.User.Address.City}",
                    StaffId = attendant.User.StaffId,
                    //RoleName = attendant.User.Role.RoleName,
                }
            }).ToList();
            return attendantResponseModels;
        }

        public AttendantResponseModel GetByTesting(string email)
        {

            var attendant = _attendantRepository.Get(x => x.User.Email == email && !x.IsDeleted && x.User.IsActive);
            if (attendant != null)
            {

                var attendantResponseModel = new AttendantResponseModel
                {
                    Message = "Attendant retrieved Successfully",
                    Status = true,
                    Data = new AttendantDTOs
                    {
                        BankAccountNumber = attendant.User.BankDetail.BankAccountNumber,
                        BankName = attendant.User.BankDetail.BankName,
                        GuarantorName = attendant.GuarantorName,
                        DateOfBirth = attendant.DateOfBirth,
                        Email = attendant.User.Email,
                        FirstName = attendant.User.FirstName,
                        Gender = attendant.Gender,
                        LastName = attendant.User.LastName,
                        GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                        MaritalStatus = attendant.MaritalStatus,
                        PhoneNumber = attendant.User.PhoneNumber,
                        //ResidentialAddress = $"{attendant.User.Address.StreetName}, {attendant.User.Address.City}",
                        StaffId = attendant.User.StaffId,
                        RoleName = attendant.User.Role.RoleName,
                    }
                };
                return attendantResponseModel;
            }
            return null;
        }

        public AttendantResponseModel GetByEmail(string email)
        {

            var attendant = _attendantRepository.GetByEmail(email);
            if (attendant != null)
            {

                var attendantResponseModel = new AttendantResponseModel
                {
                    Message = "Attendant retrieved Successfully",
                    Status = true,
                    Data = new AttendantDTOs
                    {
                        BankAccountNumber = attendant.User.BankDetail == null ? null : attendant.User.BankDetail.BankAccountNumber,
                        BankName = attendant.User.BankDetail == null ? null : attendant.User.BankDetail.BankName,
                        GuarantorName = attendant.GuarantorName,
                        DateOfBirth = attendant.DateOfBirth,
                        Email = attendant.User.Email,
                        FirstName = attendant.User.FirstName,
                        Gender = attendant.Gender,
                        LastName = attendant.User.LastName,
                        GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                        MaritalStatus = attendant.MaritalStatus,
                        PhoneNumber = attendant.User.PhoneNumber,
                        //ResidentialAddress = $"{attendant.User.Address.StreetName}, {attendant.User.Address.City}",
                        StaffId = attendant.User.StaffId,
                        RoleName = attendant.User.Role.RoleName,

                    }
                };
                return attendantResponseModel;
            }
            return null;
        }

        public AttendantResponseModel GetById(string id)
        {
            var attendant = _attendantRepository.GetById(id);
            if (attendant != null)
            {
                var attendantResponseModel = new AttendantResponseModel
                {
                    Message = "Attendant retrieved Successfully",
                    Status = true,
                    Data = new AttendantDTOs
                    {
                        BankAccountNumber = attendant.User.BankDetail.BankAccountNumber,
                        BankName = attendant.User.BankDetail.BankName,
                        GuarantorName = attendant.GuarantorName,
                        DateOfBirth = attendant.DateOfBirth,
                        Email = attendant.User.Email,
                        FirstName = attendant.User.FirstName,
                        Gender = attendant.Gender,
                        LastName = attendant.User.LastName,
                        GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                        MaritalStatus = attendant.MaritalStatus,
                        PhoneNumber = attendant.User.PhoneNumber,
                        //ResidentialAddress = $"{attendant.User.Address.StreetName}, {attendant.User.Address.City}",
                        StaffId = attendant.User.StaffId,
                        RoleName = attendant.User.Role.RoleName,

                    }
                };
                return attendantResponseModel;
            }
            return null;
        }

        public IEnumerable<AttendantResponseModel> GetByName(string name)
        {
            var attendants = _attendantRepository.GetByName(name);
            if (attendants == null)
            {
                return null;
            }
            var attendantResponseModels = attendants.Select(attendant => new AttendantResponseModel
            {
                Message = "Attendant retrieved Successfully",
                Status = true,
                Data = new AttendantDTOs
                {
                    BankAccountNumber = attendant.User.BankDetail.BankAccountNumber,
                    BankName = attendant.User.BankDetail.BankName,
                    GuarantorName = attendant.GuarantorName,
                    DateOfBirth = attendant.DateOfBirth,
                    Email = attendant.User.Email,
                    FirstName = attendant.User.FirstName,
                    Gender = attendant.Gender,
                    LastName = attendant.User.LastName,
                    GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                    MaritalStatus = attendant.MaritalStatus,
                    PhoneNumber = attendant.User.PhoneNumber,
                    //ResidentialAddress = $"{attendant.User.Address.StreetName}, {attendant.User.Address.City}",
                    StaffId = attendant.User.StaffId,
                    RoleName = attendant.User.Role.RoleName,

                }
            }).ToList();
            return attendantResponseModels;
        }

        public AttendantResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var attendant = _attendantRepository.GetByPhoneNumber(phoneNumber);
            var attendantResponseModel = new AttendantResponseModel
            {
                Message = "Attendant retrieved Successfully",
                Status = true,
                Data = new AttendantDTOs
                {
                    BankAccountNumber = attendant.User.BankDetail.BankAccountNumber,
                    BankName = attendant.User.BankDetail.BankName,
                    GuarantorName = attendant.GuarantorName,
                    DateOfBirth = attendant.DateOfBirth,
                    Email = attendant.User.Email,
                    FirstName = attendant.User.FirstName,
                    Gender = attendant.Gender,
                    LastName = attendant.User.LastName,
                    GuarantorPhoneNumber = attendant.GuarantorPhoneNumber,
                    MaritalStatus = attendant.MaritalStatus,
                    PhoneNumber = attendant.User.PhoneNumber,
                    //ResidentialAddress = $"{attendant.User.Address.StreetName}, {attendant.User.Address.City}",
                    StaffId = attendant.User.StaffId,
                    RoleName = attendant.User.Role.RoleName,

                }

            };

            return attendantResponseModel;
        }


        public AttendantResponseModel Update(AttendantResponseModel attendant)
        {

            var user = _userRepository.GetById(attendant.Data.StaffId);
            if (user == null)
            {
                return null;
            }

            user.StaffId = attendant.Data.StaffId ?? user.StaffId;
            user.Attendant.User.FirstName = attendant.Data.FirstName ?? user.Attendant.User.FirstName;
            user.Attendant.User.LastName = attendant.Data.LastName ?? user.Attendant.User.LastName;


            var attendan = _attendantRepository.GetById(attendant.Data.Id);
            if (attendan == null)
            {
                return null;
            }

            attendan.User.FirstName = attendant.Data.FirstName ?? attendan.User.FirstName;
            attendan.User.LastName = attendant.Data.LastName ?? attendan.User.LastName;
            //attendan.User.Address.StreetName = attendant.Data.ResidentialAddress ?? attendan.User.Address.StreetName;
            attendan.MaritalStatus = attendant.Data.MaritalStatus;
            attendan.User.BankDetail.BankName = attendant.Data.BankName ?? attendan.User.BankDetail.BankName;
            attendan.User.BankDetail.BankAccountNumber = attendant.Data.BankAccountNumber ?? attendan.User.BankDetail.BankAccountNumber;
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
            _userRepository.Update(user);
            return attendant;
        }
    }
}

