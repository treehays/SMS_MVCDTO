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
		private readonly IAddressRepository _addressRepository;
		private readonly IBankDetailRepository _bankDetailRepository;

		public SalesManagerService(ISalesManagerRepository salesManagerRepository, IUserRepository userRepository, IAddressRepository addressRepository, IBankDetailRepository bankDetailRepository)
		{
			_salesManagerRepository = salesManagerRepository;
			_userRepository = userRepository;
			_addressRepository = addressRepository;
			_bankDetailRepository = bankDetailRepository;
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
				//ProfilePicture = salesManager.
			};
			_userRepository.Create(user);

			var salesManage = new SalesManager
			{
				UserId = user.Id,
				FirstName = salesManager.FirstName,
				LastName = salesManager.LastName,
				DateOfBirth = salesManager.DateOfBirth,
				Gender = salesManager.Gender,
				MaritalStatus = salesManager.MaritalStatus,
				GuarantorName = salesManager.GuarantorName,
				GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
				Created = DateTime.Now,

			};
			_salesManagerRepository.Create(salesManage);

			var address = new Address
			{
				UserId = user.Id,
				StreetName = salesManager.StreetName,
				City = salesManager.City,
				PostalCode = salesManager.PostalCode,
				State = salesManager.State,
				Country = salesManager.Country,
			};
			_addressRepository.Create(address);

			var bankDetail = new BankDetail
			{
				UserId = user.Id,
				BankAccountNumber = salesManager.BankAccountNumber,
				BankName = salesManager.BankName,
			};
			_bankDetailRepository.Create(bankDetail);

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
					//RoleId = salesManager.User.RoleId,
					FirstName = salesManager.FirstName,
					LastName = salesManager.LastName,
					Email = salesManager.User.Email,
					PhoneNumber = salesManager.User.PhoneNumber,
					DateOfBirth = salesManager.DateOfBirth,
					Gender = salesManager.Gender,
					MaritalStatus = salesManager.MaritalStatus,
					BankAccountNumber = salesManager.User.BankDetail.BankAccountNumber,
					BankName = salesManager.User.BankDetail.BankName,
					GuarantorName = salesManager.GuarantorName,
					GuarantorPhoneNumber = salesManager.GuarantorPhoneNumber,
				}
			};
			return salesManage;

		}

		public bool ExistByEmail(string email)
		{
			var salesManager = _salesManagerRepository.ExistByEmail(email);
			return salesManager;
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
					//RoleId = salesManager.User.RoleId,
					FirstName = salesManager.FirstName,
					LastName = salesManager.LastName,
					Email = salesManager.User.Email,
					PhoneNumber = salesManager.User.PhoneNumber,
					DateOfBirth = salesManager.DateOfBirth,
					Gender = salesManager.Gender,
					MaritalStatus = salesManager.MaritalStatus,
					BankAccountNumber = salesManager.User.BankDetail.BankAccountNumber,
					BankName = salesManager.User.BankDetail.BankName,
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
						//RoleId = salesManager.User.RoleId,
						FirstName = salesManager.FirstName,
						LastName = salesManager.LastName,
						Email = salesManager.User.Email,
						PhoneNumber = salesManager.User.PhoneNumber,
						DateOfBirth = salesManager.DateOfBirth,
						Gender = salesManager.Gender,
						MaritalStatus = salesManager.MaritalStatus,
						BankAccountNumber = salesManager.User.BankDetail.BankAccountNumber,
						BankName = salesManager.User.BankDetail.BankName,
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
					//RoleId = salesManager.User.RoleId,
					FirstName = salesManager.FirstName,
					LastName = salesManager.LastName,
					Email = salesManager.User.Email,
					PhoneNumber = salesManager.User.PhoneNumber,
					DateOfBirth = salesManager.DateOfBirth,
					Gender = salesManager.Gender,
					MaritalStatus = salesManager.MaritalStatus,
					BankAccountNumber = salesManager.User.BankDetail.BankAccountNumber,
					BankName = salesManager.User.BankDetail.BankName,
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
						//RoleId = salesManager.User.RoleId,
						FirstName = salesManager.FirstName,
						LastName = salesManager.LastName,
						Email = salesManager.User.Email,
						PhoneNumber = salesManager.User.PhoneNumber,
						DateOfBirth = salesManager.DateOfBirth,
						Gender = salesManager.Gender,
						MaritalStatus = salesManager.MaritalStatus,
						BankAccountNumber = salesManager.User.BankDetail.BankAccountNumber,
						BankName = salesManager.User.BankDetail.BankName,
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
			salesManage.User.BankDetail.BankName = salesManager.Data.BankName;
			salesManage.User.BankDetail.BankAccountNumber = salesManager.Data.BankAccountNumber ?? salesManage.User.BankDetail.BankAccountNumber;
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
