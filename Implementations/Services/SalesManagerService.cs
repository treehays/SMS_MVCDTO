using SMS_MVCDTO.Enums;
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
        private readonly ISalesManagerRepository _salesManager;
        private readonly IUserRepository _user;
        public SalesManagerService(ISalesManagerRepository salesManager, IUserRepository user)
        {
            _salesManager = salesManager;
            _user = user;
        }

        public CreateSalesManagerRequestModel Create(CreateSalesManagerRequestModel salesManager)
        {
            var sid = User.GenerateRandomId("S");
            var user = new User
            {
                StaffId = sid,
                Password = salesManager.Password,
                Role = UserRoleType.SalesManager,
                Created = DateTime.Now,
            };
            _user.Create(user);

            var salesManage = new SalesManager
            {
                StaffId = sid,
                UserId = sid,
                FirstName = salesManager.FirstName,
                LastName = salesManager.LastName,
                Email = salesManager.Email,
                PhoneNumber = salesManager.PhoneNumber,
                HomeAddress = salesManager.HomeAddress,
                ResidentialAddress = salesManager.ResidentialAddress,
                DateOfBirth = salesManager.DateOfBirth,
                Gender = salesManager.Gender,
                MaritalStatus = salesManager.MaritalStatus,
                BankAccountNumber = salesManager.BankAccountNumber,
                BankName = salesManager.BankName,
                GuarantorName = salesManager.GuarantorName,
                GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                userRole = UserRoleType.SalesManager,
                IsActive = true,
                Created = DateTime.Now,

            };
            _salesManager.Create(salesManage);
            return salesManager;
        }

        public void Delete(string staffId)
        {
            var salesManager = _salesManager.GetById(staffId);
            if (salesManager == null)
            {
                salesManager = null;
            }
            salesManager.IsDeleted = true;
            _salesManager.Delete(salesManager);
        }

        public SalesManagerResponseModel GetByEmail(string email)
        {
            var salesManager = _salesManager.GetByEmail(email);
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
                    StaffId= salesManager.StaffId,
                    userRole = salesManager.userRole,
                    FirstName = salesManager.FirstName,
                    LastName = salesManager.LastName,
                    Email = salesManager.Email,
                    PhoneNumber = salesManager.PhoneNumber,
                    HomeAddress = salesManager.HomeAddress,
                    ResidentialAddress = salesManager.ResidentialAddress,
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

        public SalesManagerResponseModel GetById(string staffId)
        {
            var salesManager = _salesManager.GetById(staffId);
            var salesManage = new SalesManagerResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SalesManagerDTOs
                {
                    FirstName = salesManager.FirstName,
                    LastName = salesManager.LastName,
                    Email = salesManager.Email,
                    PhoneNumber = salesManager.PhoneNumber,
                    HomeAddress = salesManager.HomeAddress,
                    ResidentialAddress = salesManager.ResidentialAddress,
                    DateOfBirth = salesManager.DateOfBirth,
                    Gender = salesManager.Gender,
                    MaritalStatus = salesManager.MaritalStatus,
                    BankAccountNumber = salesManager.BankAccountNumber,
                    BankName = salesManager.BankName,
                    GuarantorName = salesManager.GuarantorName,
                    GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                    StaffId = salesManager.StaffId,
                    userRole = salesManager.userRole,
                }
            };
            return salesManage;

        }

        public IEnumerable<SalesManagerResponseModel> GetByName(string name)
        {
            var salesManagers = _salesManager.GetByName(name);
            var salesManagerResponseModels = new List<SalesManagerResponseModel>();
            foreach (var salesManager in salesManagers)
            {
                var salesManage = new SalesManagerResponseModel
                {
                    Status = true,
                    Message = "Sales Manager retrieved sucessfully.",
                    Data = new SalesManagerDTOs
                    {
                        FirstName = salesManager.FirstName,
                        LastName = salesManager.LastName,
                        Email = salesManager.Email,
                        PhoneNumber = salesManager.PhoneNumber,
                        HomeAddress = salesManager.HomeAddress,
                        ResidentialAddress = salesManager.ResidentialAddress,
                        DateOfBirth = salesManager.DateOfBirth,
                        Gender = salesManager.Gender,
                        MaritalStatus = salesManager.MaritalStatus,
                        BankAccountNumber = salesManager.BankAccountNumber,
                        BankName = salesManager.BankName,
                        GuarantorName = salesManager.GuarantorName,
                        GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                        StaffId = salesManager.StaffId,
                        userRole = salesManager.userRole,
                    }
                };
                salesManagerResponseModels.Add(salesManage);
            }

            return salesManagerResponseModels;
        }

        public SalesManagerResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var salesManager = _salesManager.GetByPhoneNumber(phoneNumber);
            var salesManage = new SalesManagerResponseModel
            {
                Status = true,
                Message = "Sales Manager retrieved sucessfully.",
                Data = new SalesManagerDTOs
                {
                    FirstName = salesManager.FirstName,
                    LastName = salesManager.LastName,
                    Email = salesManager.Email,
                    PhoneNumber = salesManager.PhoneNumber,
                    HomeAddress = salesManager.HomeAddress,
                    ResidentialAddress = salesManager.ResidentialAddress,
                    DateOfBirth = salesManager.DateOfBirth,
                    Gender = salesManager.Gender,
                    MaritalStatus = salesManager.MaritalStatus,
                    BankAccountNumber = salesManager.BankAccountNumber,
                    BankName = salesManager.BankName,
                    GuarantorName = salesManager.GuarantorName,
                    GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                    StaffId = salesManager.StaffId,
                    userRole = salesManager.userRole,
                }
            };
            return salesManage;

        }

        public IEnumerable<SalesManagerResponseModel> GetSalesManagers()
        {
            var salesManagers = _salesManager.GetSalesManagers();
            var salesManagerResponseModels = new List<SalesManagerResponseModel>();
            foreach (var salesManager in salesManagers)
            {
                var salesManage = new SalesManagerResponseModel
                {
                    Status = true,
                    Message = "Sales Manager retrieved sucessfully.",
                    Data = new SalesManagerDTOs
                    {
                        StaffId = salesManager.StaffId,
                        FirstName = salesManager.FirstName,
                        LastName = salesManager.LastName,
                        Email = salesManager.Email,
                        PhoneNumber = salesManager.PhoneNumber,
                        HomeAddress = salesManager.HomeAddress,
                        ResidentialAddress = salesManager.ResidentialAddress,
                        DateOfBirth = salesManager.DateOfBirth,
                        Gender = salesManager.Gender,
                        MaritalStatus = salesManager.MaritalStatus,
                        BankAccountNumber = salesManager.BankAccountNumber,
                        BankName = salesManager.BankName,
                        GuarantorName = salesManager.GuarantorName,
                        GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
                        userRole = salesManager.userRole,
                    }
                };
                salesManagerResponseModels.Add(salesManage);
            }

            return salesManagerResponseModels;

        }

        public SalesManagerResponseModel Update(SalesManagerResponseModel salesManager)
        {
            var salesManage = _salesManager.GetById(salesManager.Data.StaffId);
            salesManage.FirstName = salesManager.Data.FirstName ?? salesManage.FirstName;
            salesManage.LastName = salesManager.Data.LastName ?? salesManage.LastName;
            salesManage.ResidentialAddress = salesManager.Data.ResidentialAddress ?? salesManage.ResidentialAddress;
            salesManage.MaritalStatus = salesManager.Data.MaritalStatus;
            salesManage.BankName = salesManager.Data.BankName;
            salesManage.BankAccountNumber = salesManager.Data.BankAccountNumber ?? salesManage.BankAccountNumber;
            salesManage.Modified = DateTime.Now;
            _salesManager.Update(salesManage);
            return salesManager;
        }

        public UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel salesManager)
        {
            var user = _user.GetById(salesManager.StaffId);
            user.Password = salesManager.Password ?? user.Password;
            user.Modified= DateTime.Now;
            _user.UpdatePassword(user);
            return salesManager;
        }
    }
}
