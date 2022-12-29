using SMS_MVCDTO.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;
using System.Xml.Linq;

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
                    userRole = UserRoleType.SuperAdmin,
                }
            };
            return superAdmi;

        }

        public SuperAdminResponseModel GetById(string staffId)
        {
            var superAdmin = _superAdmin.GetById(staffId);
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
                    userRole = UserRoleType.SuperAdmin,
                }
            };
            return superAdmi;
        }

        public IEnumerable<SuperAdminResponseModel> GetByName(string name)
        {
            var superAdmins = _superAdmin.GetByName(name);
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
                        userRole = UserRoleType.SuperAdmin,
                    }
                };

                superAdminResponseModels.Add(superAdmi);
            }

            return superAdminResponseModels;
        }

        public SuperAdminResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var superAdmin = _superAdmin.GetByPhoneNumber(phoneNumber);
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
                    userRole = UserRoleType.SuperAdmin,
                }
            };
            return superAdmi;
        }

        public IEnumerable<SuperAdminResponseModel> GetSuperAdmins()
        {
            var superAdmins = _superAdmin.GetSuperAdmins();
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
                        userRole = UserRoleType.SuperAdmin,
                    }
                };

                superAdminResponseModels.Add(superAdmi);
            }

            return superAdminResponseModels;
        }

        public UpdateSuperAdminRequestModel Update(UpdateSuperAdminRequestModel superAdmin)
        {
            var superAdmi = _superAdmin.GetById(superAdmin.StaffId);
            superAdmi.FirstName = superAdmin.FirstName ?? superAdmi.FirstName;
            superAdmi.LastName = superAdmin.LastName ?? superAdmi.LastName;
            superAdmi.ResidentialAddress = superAdmin.ResidentialAddress ?? superAdmi.ResidentialAddress;
            superAdmi.MaritalStatus = superAdmin.MaritalStatus;
            superAdmi.BankName = superAdmin.BankName;
            superAdmi.BankAccountNumber = superAdmin.BankAccountNumber ?? superAdmi.BankAccountNumber;
            _superAdmin.Update(superAdmi);
            return superAdmin;
        }
    }
}
