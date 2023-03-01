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
        private readonly IAddressRepository _addressRepository;
        private readonly IBankDetailRepository _bankDetailRepository;

        public SuperAdminService(ISuperAdminRepository superAdmin, IUserRepository user, IBankDetailRepository bankDetailRepository, IAddressRepository addressRepository)
        {
            _superAdminRepository = superAdmin;
            _userRepository = user;
            _addressRepository = addressRepository;
            _bankDetailRepository = bankDetailRepository;
        }

        public CreateSuperAdminRequestModel Create(CreateSuperAdminRequestModel superAdmin)
        {

            var sid = User.GenerateRandomId("S");
            var user = new User
            {
                StaffId = sid,
                Password = superAdmin.Password,
                RoleId = 1,
                Email = superAdmin.Email,
                PhoneNumber = superAdmin.PhoneNumber,
                ProfilePicture = superAdmin.ProfilePicture,
                IsActive = true,
                Created = DateTime.Now,
            };
            _userRepository.Create(user);

            var superAdmi = new SuperAdmin
            {
                UserId = user.Id,
                FirstName = superAdmin.FirstName,
                LastName = superAdmin.LastName,
                DateOfBirth = superAdmin.DateOfBirth,
                Gender = superAdmin.Gender,
                MaritalStatus = superAdmin.MaritalStatus,
                Created = DateTime.Now,
            };
            _superAdminRepository.Create(superAdmi);

            var address = new Address
            {
                UserId = user.Id,
                StreetName = superAdmin.StreetName,
                City = superAdmin.City,
                PostalCode = superAdmin.PostalCode,
                State = superAdmin.State,
                Country = superAdmin.Country,
            };
            _addressRepository.Create(address);

            var bankDetails = new BankDetail
            {
                UserId = user.Id,
                BankAccountNumber = superAdmin.BankAccountNumber,
                BankName = superAdmin.BankName,
                //AccountType = superAdmin.
            };
            _bankDetailRepository.Create(bankDetails);

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
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    BankName = superAdmin.User.BankDetail.BankName,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
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
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    BankName = superAdmin.User.BankDetail.BankName,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
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

            var superAdminResponseModels = superAdmins.Select(superAdmin => new SuperAdminResponseModel
            {
                Status = true,
                Message = "Super admin retrieved sucessfully.",
                Data = new SuperAdminDTOs
                {
                    FirstName = superAdmin.FirstName,
                    LastName = superAdmin.LastName,
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    BankName = superAdmin.User.BankDetail.BankName,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
                    ProfilePicture = superAdmin.User.ProfilePicture,

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
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    BankName = superAdmin.User.BankDetail.BankName,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
                    ProfilePicture = superAdmin.User.ProfilePicture,

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
                        Email = superAdmin.User.Email,
                        PhoneNumber = superAdmin.User.PhoneNumber,
                        //HomeAddress = superAdmin.User.Address.StreetName,
                        DateOfBirth = superAdmin.DateOfBirth,
                        Gender = superAdmin.Gender,
                        MaritalStatus = superAdmin.MaritalStatus,
                        BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                        BankName = superAdmin.User.BankDetail.BankName,
                        RoleName = superAdmin.User.Role.RoleName,
                        StaffId = superAdmin.User.StaffId,
                        ProfilePicture = superAdmin.User.ProfilePicture,

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
            //user.SuperAdmin.FirstName = superAdmin.Data.FirstName ?? user.SuperAdmin.FirstName;
            //user.SuperAdmin.LastName = superAdmin.Data.LastName ?? user.SuperAdmin.LastName;
            user.ProfilePicture = superAdmin.Data.ProfilePicture ?? user.ProfilePicture;
            var superAdmi = _superAdminRepository.GetById(superAdmin.Data.StaffId);
            superAdmi.FirstName = superAdmin.Data.FirstName ?? superAdmi.FirstName;
            superAdmi.LastName = superAdmin.Data.LastName ?? superAdmi.LastName;
            // superAdmi.ResidentialAddress = superAdmin.Data.ResidentialAddress ?? superAdmi.ResidentialAddress;
            superAdmi.MaritalStatus = superAdmin.Data.MaritalStatus;
            //superAdmi.BankName = superAdmin.Data.BankName;
            //superAdmi.BankAccountNumber = superAdmin.Data.BankAccountNumber ?? superAdmi.BankAccountNumber;
            superAdmi.Modified = DateTime.Now;
            //_superAdminRepository.Update(superAdmi);
            return superAdmin;
        }
    }
}
