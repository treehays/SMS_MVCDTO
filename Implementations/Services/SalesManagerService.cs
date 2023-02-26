using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Implementations.Repositories;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SalesManagerDTOs;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using SMS_MVCDTO.Models.Entities;
//using System.Xml.Linq;

namespace SMS_MVCDTO.Implementations.Service
{
    public class SalesManagerService : ISalesManagerService
    {
        private readonly ISalesManagerRepository _salesManagerRepository;
        private readonly IUserRepository _userRepository;
        public SalesManagerService(ISalesManagerRepository salesManagerRepository, IUserRepository userRepository)
        {
            _salesManagerRepository = salesManagerRepository;
            _userRepository = userRepository;
        }

        public CreateSalesManagerRequestModel Create(CreateSalesManagerRequestModel salesManager)
        {
            var sid = User.GenerateRandomId("S");
            var user = new User
            {
                StaffId = sid,
                Password = salesManager.Password,
                RoleId = 2,
                Created = DateTime.Now,
                Email = salesManager.Email,
                PhoneNumber = salesManager.PhoneNumber,
                IsActive = true,
            };
            _userRepository.Create(user);

            var salesManage = new SalesManager
            {
                FirstName = salesManager.FirstName,
                LastName = salesManager.LastName,
                /*              HomeAddress = salesManager.HomeAddress,
                              ResidentialAddress = salesManager.ResidentialAddress,*/
                DateOfBirth = salesManager.DateOfBirth,
                Gender = salesManager.Gender,
                MaritalStatus = salesManager.MaritalStatus,
                BankAccountNumber = salesManager.BankAccountNumber,
                BankName = salesManager.BankName,
                GuarantorName = salesManager.GuarantorName,
                GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                Created = DateTime.Now,

            };
            _salesManagerRepository.Create(salesManage);
            return salesManager;
        }

        public void Delete(string staffId)
        {
            var salesManager = _salesManagerRepository.GetById(staffId);
            if (salesManager == null)
            {
                salesManager = null;
            }
            salesManager.IsDeleted = true;
            _salesManagerRepository.Delete(salesManager);
        }

        public SalesManagerResponseModel GetByEmail(string email)
        {
            var salesManager = _salesManagerRepository.GetByEmail(email);
            if (salesManager == null)
            {
                return null;
            }
            var salesManage = new SalesManagerResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SalesManagerDTOs
                {
                    StaffId = salesManager.User.StaffId,
                    RoleId = salesManager.User.RoleId,
                    FirstName = salesManager.FirstName,
                    LastName = salesManager.LastName,
                    Email = salesManager.User.Email,
                    PhoneNumber = salesManager.User.PhoneNumber,
                    DateOfBirth = salesManager.DateOfBirth,
                    Gender = salesManager.Gender,
                    MaritalStatus = salesManager.MaritalStatus,
                    BankAccountNumber = salesManager.BankAccountNumber,
                    BankName = salesManager.BankName,
                    GuarantorName = salesManager.GuarantorName,
                    GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                    //HomeAddress = salesManager.HomeAddress,
                    //ResidentialAddress = salesManager.ResidentialAddress,
                }
            };
            return salesManage;

        }

        public SalesManagerResponseModel GetById(string staffId)
        {
            var salesManager = _salesManagerRepository.GetById(staffId);
            var salesManage = new SalesManagerResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SalesManagerDTOs
                {
                    StaffId = salesManager.User.StaffId,
                    RoleId = salesManager.User.RoleId,
                    FirstName = salesManager.FirstName,
                    LastName = salesManager.LastName,
                    Email = salesManager.User.Email,
                    PhoneNumber = salesManager.User.PhoneNumber,
                    DateOfBirth = salesManager.DateOfBirth,
                    Gender = salesManager.Gender,
                    MaritalStatus = salesManager.MaritalStatus,
                    BankAccountNumber = salesManager.BankAccountNumber,
                    BankName = salesManager.BankName,
                    GuarantorName = salesManager.GuarantorName,
                    GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                }
            };
            return salesManage;

        }

        public IEnumerable<SalesManagerResponseModel> GetByName(string name)
        {
            var salesManagers = _salesManagerRepository.GetByName(name);
            var salesManagerResponseModels = new List<SalesManagerResponseModel>();
            foreach (var salesManager in salesManagers)
            {
                var salesManage = new SalesManagerResponseModel
                {
                    Status = true,
                    Message = "Sales Manager retrieved sucessfully.",
                    Data = new SalesManagerDTOs
                    {
                        StaffId = salesManager.User.StaffId,
                        RoleId = salesManager.User.RoleId,
                        FirstName = salesManager.FirstName,
                        LastName = salesManager.LastName,
                        Email = salesManager.User.Email,
                        PhoneNumber = salesManager.User.PhoneNumber,
                        DateOfBirth = salesManager.DateOfBirth,
                        Gender = salesManager.Gender,
                        MaritalStatus = salesManager.MaritalStatus,
                        BankAccountNumber = salesManager.BankAccountNumber,
                        BankName = salesManager.BankName,
                        GuarantorName = salesManager.GuarantorName,
                        GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                    }
                };
                salesManagerResponseModels.Add(salesManage);
            }

            return salesManagerResponseModels;
        }

        public SalesManagerResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var salesManager = _salesManagerRepository.GetByPhoneNumber(phoneNumber);
            var salesManage = new SalesManagerResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SalesManagerDTOs
                {
                    StaffId = salesManager.User.StaffId,
                    RoleId = salesManager.User.RoleId,
                    FirstName = salesManager.FirstName,
                    LastName = salesManager.LastName,
                    Email = salesManager.User.Email,
                    PhoneNumber = salesManager.User.PhoneNumber,
                    DateOfBirth = salesManager.DateOfBirth,
                    Gender = salesManager.Gender,
                    MaritalStatus = salesManager.MaritalStatus,
                    BankAccountNumber = salesManager.BankAccountNumber,
                    BankName = salesManager.BankName,
                    GuarantorName = salesManager.GuarantorName,
                    GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                }
            };
            return salesManage;

        }

        public IEnumerable<SalesManagerResponseModel> GetSalesManagers()
        {
            var salesManagers = _salesManagerRepository.GetSalesManagers();
            var salesManagerResponseModels = new List<SalesManagerResponseModel>();
            foreach (var salesManager in salesManagers)
            {
                var salesManage = new SalesManagerResponseModel
                {
                    Status = true,
                    Message = "Sales Manager retrieved sucessfully.",
                    Data = new SalesManagerDTOs
                    {
                        StaffId = salesManager.User.StaffId,
                        RoleId = salesManager.User.RoleId,
                        FirstName = salesManager.FirstName,
                        LastName = salesManager.LastName,
                        Email = salesManager.User.Email,
                        PhoneNumber = salesManager.User.PhoneNumber,
                        DateOfBirth = salesManager.DateOfBirth,
                        Gender = salesManager.Gender,
                        MaritalStatus = salesManager.MaritalStatus,
                        BankAccountNumber = salesManager.BankAccountNumber,
                        BankName = salesManager.BankName,
                        GuarantorName = salesManager.GuarantorName,
                        GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                    }
                };
                salesManagerResponseModels.Add(salesManage);
            }

            return salesManagerResponseModels;

        }

        public SalesManagerResponseModel Update(SalesManagerResponseModel salesManager)
        {
            var salesManage = _salesManagerRepository.GetById(salesManager.Data.StaffId);
            salesManage.FirstName = salesManager.Data.FirstName ?? salesManage.FirstName;
            salesManage.LastName = salesManager.Data.LastName ?? salesManage.LastName;
            salesManage.MaritalStatus = salesManager.Data.MaritalStatus;
            salesManage.BankName = salesManager.Data.BankName;
            salesManage.BankAccountNumber = salesManager.Data.BankAccountNumber ?? salesManage.BankAccountNumber;
            salesManage.Modified = DateTime.Now;
            _salesManagerRepository.Update(salesManage);
            return salesManager;
        }

        public UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel salesManager)
        {
            var user = _userRepository.GetById(salesManager.StaffId);
            user.Password = salesManager.Password ?? user.Password;
            user.Modified = DateTime.Now;
            _userRepository.Update(user);
            return salesManager;
        }
    }
}
