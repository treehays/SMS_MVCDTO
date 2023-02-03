using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Service
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminRepository _superAdmin;
        private readonly IUserRepository _user;
        public SuperAdminService(ISuperAdminRepository superAdmin, IUserRepository user)
        {
            _superAdmin = superAdmin;
            _user = user;
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
            };
            _user.Create(user);
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
            _superAdmin.Create(superAdmi);
            return superAdmin;
        }

        public void Delete(string staffId)
        {
            var superAdmin = _superAdmin.GetById(staffId);
            if (superAdmin == null)
            {
                superAdmin = null;
            }
            superAdmin.IsDeleted = true;
            _superAdmin.Delete(superAdmin);
        }

        public SuperAdminResponseModel GetByEmail(string email)
        {
            var superAdmin = _superAdmin.GetByEmail(email);
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

        public SuperAdminResponseModel GetById(string staffId)
        {
            var superAdmin = _superAdmin.GetById(staffId);
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

        public IEnumerable<SuperAdminResponseModel> GetByName(string name)
        {
            var superAdmins = _superAdmin.GetByName(name);
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
            var superAdmin = _superAdmin.GetByPhoneNumber(phoneNumber);
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
            var superAdmins = _superAdmin.GetSuperAdmins();
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
            var superAdmi = _superAdmin.GetById(superAdmin.Data.StaffId);
            superAdmi.FirstName = superAdmin.Data.FirstName ?? superAdmi.FirstName;
            superAdmi.LastName = superAdmin.Data.LastName ?? superAdmi.LastName;
            superAdmi.ResidentialAddress = superAdmin.Data.ResidentialAddress ?? superAdmi.ResidentialAddress;
            superAdmi.MaritalStatus = superAdmin.Data.MaritalStatus;
            superAdmi.BankName = superAdmin.Data.BankName;
            superAdmi.BankAccountNumber = superAdmin.Data.BankAccountNumber ?? superAdmi.BankAccountNumber;
            superAdmi.Modified = DateTime.Now;
            _superAdmin.Update(superAdmi);
            return superAdmin;
        }
    }
}
