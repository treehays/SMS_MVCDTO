using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.CustomerDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customer;
        private readonly IUserRepository _user;
        public CustomerService(ICustomerRepository customer, IUserRepository user)
        {
            _customer = customer;
            _user = user;
        }

        public CreateCustomerRequestModel Create(CreateCustomerRequestModel customer)
        {
            var sid = User.GenerateRandomId("C");
            var user = new User
            {
                StaffId = sid,
                Password = customer.Password,
                Role = UserRoleType.Customer,
                Created = DateTime.Now
            };
            _user.Create(user);

            var custome = new Customer
            {
                StaffId = sid,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                Created = DateTime.Now,
                IsActive = true,
                UserId = sid,

            };
            _customer.Create(custome);

            return customer;
        }
        public void Delete(string staffId)
        {
            var customer = _customer.GetById(staffId);
            customer.IsDeleted = true;

            _customer.Delete(customer);
        }

        public CustomerResponseModel GetByEmail(string email)
        {
            var customer = _customer.GetByEmail(email);
            if (customer == null)
            {
                return null;
            }

            var customerResponseModel = new CustomerResponseModel
            {
                Message = "Customer retrieved successfully.",
                Status = true,
                Data = new CustomerDTOs
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    Gender = customer.Gender,
                    MaritalStatus = customer.MaritalStatus,
                    StaffId = customer.StaffId,
                    Address = customer.Address,
                    IsActive = customer.IsActive,
                    IsDelete = customer.IsDeleted,
                    UserRole = customer.userRole,
                    
                }
            };
            return customerResponseModel;
        }

        public CustomerResponseModel GetById(string staffId)
        {
            var customer = _customer.GetById(staffId);
            if (customer == null)
            {
                return null;
            }

            var customerResponseModel = new CustomerResponseModel
            {
                Message = "Customer retrieved successfully.",
                Status = true,
                Data = new CustomerDTOs
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    Gender = customer.Gender,
                    MaritalStatus = customer.MaritalStatus,
                    StaffId = customer.StaffId,
                    Address = customer.Address,
                    IsActive = customer.IsActive,
                    IsDelete = customer.IsDeleted,
                    UserRole = customer.userRole,
                }
            };
            return customerResponseModel;
        }

        public IEnumerable<CustomerResponseModel> GetByName(string name)
        {
            var customers = _customer.GetByName(name);
            var customerResponseModels = new List<CustomerResponseModel>();
            foreach (var customer in customers)
            {
                var customerResponseModel = new CustomerResponseModel
                {
                    Message = "Customer retrieved successfully.",
                    Status = true,
                    Data = new CustomerDTOs
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        DateOfBirth = customer.DateOfBirth,
                        Email = customer.Email,
                        Gender = customer.Gender,
                        MaritalStatus = customer.MaritalStatus,
                        StaffId = customer.StaffId,
                        Address = customer.Address,
                        IsActive = customer.IsActive,
                        IsDelete = customer.IsDeleted,
                        UserRole = customer.userRole,
                    }
                };
                customerResponseModels.Add(customerResponseModel);
            }
            return customerResponseModels;
        }

        public CustomerResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var customer = _customer.GetByPhoneNumber(phoneNumber);
            if (customer == null)
            {
                return null;
            }

            var customerResponseModel = new CustomerResponseModel
            {
                Message = "Customer retrieved successfully.",
                Status = true,
                Data = new CustomerDTOs
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    Gender = customer.Gender,
                    MaritalStatus = customer.MaritalStatus,
                    StaffId = customer.StaffId,
                    Address = customer.Address,
                    IsActive = customer.IsActive,
                    IsDelete = customer.IsDeleted,
                    UserRole = customer.userRole,
                }
            };
            return customerResponseModel;
        }

        public IEnumerable<CustomerResponseModel> GetCustomers()
        {
            var customers = _customer.GetCustomers();
            var customerResponseModels = new List<CustomerResponseModel>();
            foreach (var customer in customers)
            {
                var customerResponseModel = new CustomerResponseModel
                {
                    Message = "Customer retrieved successfully.",
                    Status = true,
                    Data = new CustomerDTOs
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        DateOfBirth = customer.DateOfBirth,
                        Email = customer.Email,
                        Gender = customer.Gender,
                        MaritalStatus = customer.MaritalStatus,
                        StaffId = customer.StaffId,
                        Address = customer.Address,
                        IsActive = customer.IsActive,
                        IsDelete = customer.IsDeleted,
                        UserRole = customer.userRole,
                    }
                };
                customerResponseModels.Add(customerResponseModel);
            }
            return customerResponseModels;
        }


        public CustomerResponseModel Update(CustomerResponseModel customer)
        {
            var custome = _customer.GetById(customer.Data.StaffId);
            if (custome == null)
            {
                return null;
            }
            custome.FirstName = customer.Data.FirstName ?? custome.FirstName;
            custome.LastName = customer.Data.LastName ?? custome.LastName;
            custome.Address = customer.Data.Address ?? custome.Address;
            custome.MaritalStatus = customer.Data.MaritalStatus;
            custome.Modified = DateTime.Now;
            _customer.Update(custome);
            return customer;

        }

        public UpdateCustomerPasswordRequestModel UpdatePassword(UpdateCustomerPasswordRequestModel customer)
        {
            //var custome = _customer.GetById(customer.StaffId);

            var user = _user.GetById(customer.StaffId);
            if (user == null)
            {
                return null;
            }
            user.Password = customer.Password;
            user.Modified = DateTime.Now;
            _user.UpdatePassword(user);
            return customer;

        }
    }
}
