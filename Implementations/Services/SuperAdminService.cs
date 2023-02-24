using Org.BouncyCastle.Asn1.Ocsp;
using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Service
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminRepository _superAdminRepository;
        private readonly IUserRepository _userRepository;
        public SuperAdminService(ISuperAdminRepository superAdmin, IUserRepository user)
        {
            _superAdminRepository = superAdmin;
            _userRepository = user;
        }

        public CreateSuperAdminRequestModel Create(CreateSuperAdminRequestModel superAdmin)
        {
            var sid = User.GenerateRandomId("S");
            var user = new User
            {
                StaffId = sid,
                Password = superAdmin.Password,
                Created = DateTime.Now,
                Role = UserRoleType.SuperAdmin,
                FirstName = superAdmin.FirstName,
                LastName = superAdmin.LastName,
                ProfilePicture = superAdmin.ProfilePicture,
            };
            _userRepository.Create(user);
            var superAdmi = new SuperAdmin
            {
                StaffId = sid,
                UserId = sid,
                FirstName = superAdmin.FirstName,
                LastName = superAdmin.LastName,
                Email = superAdmin.Email,
                PhoneNumber = superAdmin.PhoneNumber,
                HomeAddress = superAdmin.HomeAddress,
                ResidentialAddress = superAdmin.ResidentialAddress,
                DateOfBirth = superAdmin.DateOfBirth,
                Gender = superAdmin.Gender,
                MaritalStatus = superAdmin.MaritalStatus,
                BankAccountNumber = superAdmin.BankAccountNumber,
                BankName = superAdmin.BankName,
                GuarantorName = superAdmin.GuarantorName,
                GuarantorPhoneNumber = superAdmin.GuarantorPhoneNumber,
                userRole = UserRoleType.SuperAdmin,
                Created = DateTime.Now,
                IsActive = true,
            };
            _superAdminRepository.Create(superAdmi);
            return superAdmin;
        }

        public void Delete(string staffId)
        {
            var user = _userRepository.GetById(staffId);
            if (user == null)
            { }

            user.IsDeleted = true;
            var superAdmin = _superAdminRepository.GetById(staffId);
            superAdmin.IsDeleted = true;
            _superAdminRepository.Update(superAdmin);
        }

        public SuperAdminResponseModel GetByEmail(string email)
        {
            var superAdmin = _superAdminRepository.GetByEmail(email);
            if (superAdmin == null)
            {
                return null;
            }
            var superAdmi = new SuperAdminResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SuperAdminDTOs
                {
                    FirstName = superAdmin.FirstName,
                    LastName = superAdmin.LastName,
                    Email = superAdmin.Email,
                    PhoneNumber = superAdmin.PhoneNumber,
                    HomeAddress = superAdmin.HomeAddress,
                    ResidentialAddress = superAdmin.ResidentialAddress,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.BankAccountNumber,
                    BankName = superAdmin.BankName,
                    GuarantorName = superAdmin.GuarantorName,
                    GuarantorPhoneNumber = superAdmin.GuarantorPhoneNumber,
                    userRole = superAdmin.userRole,
                    StaffId = superAdmin.StaffId,
                }
            };
            return superAdmi;

        }

        public bool EmailExist(string email)
        {
            var emailExist = _superAdminRepository.EmailExist(email);
            return emailExist;
        }
        public SuperAdminResponseModel GetById(string staffId)
        {
            var superAdmin = _superAdminRepository.GetById(staffId);
            if (superAdmin == null)
            {
                return null;
            }
            var user = _userRepository.GetById(staffId);
            var superAdmi = new SuperAdminResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SuperAdminDTOs
                {
                    FirstName = superAdmin.FirstName,
                    LastName = superAdmin.LastName,
                    Email = superAdmin.Email,
                    PhoneNumber = superAdmin.PhoneNumber,
                    HomeAddress = superAdmin.HomeAddress,
                    ResidentialAddress = superAdmin.ResidentialAddress,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.BankAccountNumber,
                    BankName = superAdmin.BankName,
                    GuarantorName = superAdmin.GuarantorName,
                    GuarantorPhoneNumber = superAdmin.GuarantorPhoneNumber,
                    userRole = superAdmin.userRole,
                    StaffId = superAdmin.StaffId,
                    ProfilePicture = user.ProfilePicture,
                }
            };
            return superAdmi;
        }

        public IEnumerable<SuperAdminResponseModel> GetByName(string name)
        {
            var superAdmins = _superAdminRepository.GetByName(name);
            if (superAdmins == null)
            {
                return null;
            }

            var superAdminResponseModels = superAdmins.Select(item => new SuperAdminResponseModel
            {
                Status = true,
                Message = "Super admin retrieved sucessfully.",
                Data = new SuperAdminDTOs
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    HomeAddress = item.HomeAddress,
                    ResidentialAddress = item.ResidentialAddress,
                    DateOfBirth = item.DateOfBirth,
                    Gender = item.Gender,
                    MaritalStatus = item.MaritalStatus,
                    BankAccountNumber = item.BankAccountNumber,
                    BankName = item.BankName,
                    GuarantorName = item.GuarantorName,
                    GuarantorPhoneNumber = item.GuarantorPhoneNumber,
                    userRole = item.userRole,
                    StaffId = item.StaffId,

                }
            }).ToList();

            return superAdminResponseModels;

        }

        public SuperAdminResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var superAdmin = _superAdminRepository.GetByPhoneNumber(phoneNumber);
            if (superAdmin == null)
            {
                return null;
            }

            var superAdmi = new SuperAdminResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SuperAdminDTOs
                {
                    FirstName = superAdmin.FirstName,
                    LastName = superAdmin.LastName,
                    Email = superAdmin.Email,
                    PhoneNumber = superAdmin.PhoneNumber,
                    HomeAddress = superAdmin.HomeAddress,
                    ResidentialAddress = superAdmin.ResidentialAddress,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.BankAccountNumber,
                    BankName = superAdmin.BankName,
                    GuarantorName = superAdmin.GuarantorName,
                    GuarantorPhoneNumber = superAdmin.GuarantorPhoneNumber,
                    userRole = superAdmin.userRole,
                    StaffId = superAdmin.StaffId,
                }
            };
            return superAdmi;
        }

        public IEnumerable<SuperAdminResponseModel> GetSuperAdmins()
        {
            var superAdmins = _superAdminRepository.GetSuperAdmins();
            if (superAdmins == null)
            {
                return null;
            }

            var superAdminResponseModels = new List<SuperAdminResponseModel>();
            foreach (var superAdmin in superAdmins)
            {
                var superAdmi = new SuperAdminResponseModel
                {
                    Status = true,
                    Message = "Super admin retrieved sucessfully.",
                    Data = new SuperAdminDTOs
                    {
                        FirstName = superAdmin.FirstName,
                        LastName = superAdmin.LastName,
                        Email = superAdmin.Email,
                        PhoneNumber = superAdmin.PhoneNumber,
                        HomeAddress = superAdmin.HomeAddress,
                        ResidentialAddress = superAdmin.ResidentialAddress,
                        DateOfBirth = superAdmin.DateOfBirth,
                        Gender = superAdmin.Gender,
                        MaritalStatus = superAdmin.MaritalStatus,
                        BankAccountNumber = superAdmin.BankAccountNumber,
                        BankName = superAdmin.BankName,
                        GuarantorName = superAdmin.GuarantorName,
                        GuarantorPhoneNumber = superAdmin.GuarantorPhoneNumber,
                        userRole = superAdmin.userRole,
                        StaffId = superAdmin.StaffId,
                    }
                };

                superAdminResponseModels.Add(superAdmi);
            }

            return superAdminResponseModels;
        }

        public SuperAdminResponseModel Update(SuperAdminResponseModel superAdmin)
        {
            var user = _userRepository.GetById(superAdmin.Data.StaffId);
            if (user == null)
            {
                return null;
            }
            user.StaffId = superAdmin.Data.StaffId ?? user.StaffId;
            user.FirstName = superAdmin.Data.FirstName ?? user.FirstName;
            user.LastName = superAdmin.Data.LastName ?? user.LastName;
            user.ProfilePicture = superAdmin.Data.ProfilePicture ?? user.ProfilePicture;
            //_userRepository.Update(superAdmi);
            var superAdmi = _superAdminRepository.GetById(superAdmin.Data.StaffId);
            superAdmi.FirstName = superAdmin.Data.FirstName ?? superAdmi.FirstName;
            superAdmi.LastName = superAdmin.Data.LastName ?? superAdmi.LastName;
            superAdmi.ResidentialAddress = superAdmin.Data.ResidentialAddress ?? superAdmi.ResidentialAddress;
            superAdmi.MaritalStatus = superAdmin.Data.MaritalStatus;
            superAdmi.BankName = superAdmin.Data.BankName;
            superAdmi.BankAccountNumber = superAdmin.Data.BankAccountNumber ?? superAdmi.BankAccountNumber;
            superAdmi.Modified = DateTime.Now;
            //_superAdminRepository.Update(superAdmi);
            return superAdmin;
        }
    }
}
