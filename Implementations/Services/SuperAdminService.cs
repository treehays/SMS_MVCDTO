
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Models.Entities;
using System.Security.Cryptography;
using System.Text;

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
            //this encrypt the password to base 64 strring (Very week)
            //var encryptPasswordBase64 = System.Text.Encoding.UTF8.GetBytes(superAdmin.Password);
            //superAdmin.Password = System.Convert.ToBase64String(encryptPasswordBase64);


            //using RFC Encryption
            var encryptionKey = "QWhtYWQxMjM=";
            var clearBytes = Encoding.Unicode.GetBytes(superAdmin.Password);
            using (Aes encryptor = Aes.Create())
            {
                var pbd = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pbd.GetBytes(32);
                encryptor.IV = pbd.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    superAdmin.Password = Convert.ToBase64String(ms.ToArray());
                }
            }

            var sid = User.GenerateRandomId("S");
            var user = new User
            {
                StaffId = sid,
                FirstName = superAdmin.FirstName,
                LastName = superAdmin.LastName,
                Password = superAdmin.Password,
                RoleId = "1",
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
                    FirstName = superAdmin.User.FirstName,
                    LastName = superAdmin.User.LastName,
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    //BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    //BankName = superAdmin.User.BankDetail.BankName,
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
                    FirstName = superAdmin.User.FirstName,
                    LastName = superAdmin.User.LastName,
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
                    ProfilePicture = user.ProfilePicture,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    //BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    //BankName = superAdmin.User.BankDetail.BankName,
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
                    FirstName = superAdmin.User.FirstName,
                    LastName = superAdmin.User.LastName,
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
                    ProfilePicture = superAdmin.User.ProfilePicture,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    //BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    //BankName = superAdmin.User.BankDetail.BankName,

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
                    FirstName = superAdmin.User.FirstName,
                    LastName = superAdmin.User.LastName,
                    Email = superAdmin.User.Email,
                    PhoneNumber = superAdmin.User.PhoneNumber,
                    DateOfBirth = superAdmin.DateOfBirth,
                    Gender = superAdmin.Gender,
                    MaritalStatus = superAdmin.MaritalStatus,
                    RoleName = superAdmin.User.Role.RoleName,
                    StaffId = superAdmin.User.StaffId,
                    ProfilePicture = superAdmin.User.ProfilePicture,
                    //HomeAddress = superAdmin.User.Address.StreetName,
                    //BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                    //BankName = superAdmin.User.BankDetail.BankName,

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
                        FirstName = superAdmin.User.FirstName,
                        LastName = superAdmin.User.LastName,
                        Email = superAdmin.User.Email,
                        PhoneNumber = superAdmin.User.PhoneNumber,
                        DateOfBirth = superAdmin.DateOfBirth,
                        Gender = superAdmin.Gender,
                        MaritalStatus = superAdmin.MaritalStatus,
                        RoleName = superAdmin.User.Role.RoleName,
                        StaffId = superAdmin.User.StaffId,
                        //ProfilePicture = superAdmin.User.ProfilePicture,
                        //HomeAddress = superAdmin.User.Address.StreetName,
                        //BankAccountNumber = superAdmin.User.BankDetail.BankAccountNumber,
                        //BankName = superAdmin.User.BankDetail.BankName,

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
            user.ProfilePicture = superAdmin.Data.ProfilePicture ?? user.ProfilePicture;
            var superAdmi = _superAdminRepository.GetById(superAdmin.Data.StaffId);
            superAdmi.User.FirstName = superAdmin.Data.FirstName ?? superAdmi.User.FirstName;
            superAdmi.User.LastName = superAdmin.Data.LastName ?? superAdmi.User.LastName;
            superAdmi.MaritalStatus = superAdmin.Data.MaritalStatus;
            superAdmi.Modified = DateTime.Now;
            //user.SuperAdmin.FirstName = superAdmin.Data.FirstName ?? user.SuperAdmin.FirstName;
            //user.SuperAdmin.LastName = superAdmin.Data.LastName ?? user.SuperAdmin.LastName;
            // superAdmi.ResidentialAddress = superAdmin.Data.ResidentialAddress ?? superAdmi.ResidentialAddress;
            //superAdmi.BankName = superAdmin.Data.BankName;
            //superAdmi.BankAccountNumber = superAdmin.Data.BankAccountNumber ?? superAdmi.BankAccountNumber;
            _superAdminRepository.Update(superAdmi);
            return superAdmin;
        }
    }
}
