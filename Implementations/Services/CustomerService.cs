using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.CustomerDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public CreateCustomerRequestModel Create(CreateCustomerRequestModel customer)
        {
            var sid = User.GenerateRandomId("C");
            var user = new User
            {
                StaffId = sid,
                Password = customer.Password,
                RoleId = 4,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Created = DateTime.Now
            };
            _userRepository.Create(user);

            var custome = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Created = DateTime.Now,

            };
            _customerRepository.Create(custome);

            return customer;
        }

        public bool CustomerExist(string staffId)
        {
            var customer = _customerRepository.CustomerExist(staffId);
            return customer;
        }

        public void Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            customer.IsDeleted = true;

            _customerRepository.Delete(customer);
        }

        public CustomerResponseModel GetByEmail(string email)
        {
            var customer = _customerRepository.GetByEmail(email);
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
                    PhoneNumber = customer.User.PhoneNumber,
                    Email = customer.User.Email,
                    Gender = customer.Gender,
                    StaffId = customer.User.StaffId,
                    Address = customer.Address.StreetName,
                    IsActive = customer.User.IsActive,
                    IsDelete = customer.IsDeleted,
                    RoleId = customer.User.RoleId,

                }
            };
            return customerResponseModel;
        }

        public CustomerResponseModel GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
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
                    PhoneNumber = customer.User.PhoneNumber,
                    Email = customer.User.Email,
                    Gender = customer.Gender,
                    StaffId = customer.User.StaffId,
                    Address = customer.Address.StreetName,
                    IsActive = customer.User.IsActive,
                    IsDelete = customer.IsDeleted,
                    RoleId = customer.User.RoleId,
                }
            };
            return customerResponseModel;
        }

        public IEnumerable<CustomerResponseModel> GetByName(string name)
        {
            var customers = _customerRepository.GetByName(name);
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
                        PhoneNumber = customer.User.PhoneNumber,
                        Email = customer.User.Email,
                        Gender = customer.Gender,
                        StaffId = customer.User.StaffId,
                        Address = customer.Address.StreetName,
                        IsActive = customer.User.IsActive,
                        IsDelete = customer.IsDeleted,
                        RoleId = customer.User.RoleId,
                    }
                };
                customerResponseModels.Add(customerResponseModel);
            }
            return customerResponseModels;
        }

        public CustomerResponseModel GetByPhoneNumber(string phoneNumber)
        {
            var customer = _customerRepository.GetByPhoneNumber(phoneNumber);
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
                    PhoneNumber = customer.User.PhoneNumber,
                    Email = customer.User.Email,
                    Gender = customer.Gender,
                    StaffId = customer.User.StaffId,
                    Address = customer.Address.StreetName,
                    IsActive = customer.User.IsActive,
                    IsDelete = customer.IsDeleted,
                    RoleId = customer.User.RoleId,
                }
            };
            return customerResponseModel;
        }

        public IEnumerable<CustomerResponseModel> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
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
                        PhoneNumber = customer.User.PhoneNumber,
                        Email = customer.User.Email,
                        Gender = customer.Gender,
                        StaffId = customer.User.StaffId,
                        Address = customer.Address.StreetName,
                        IsActive = customer.User.IsActive,
                        IsDelete = customer.IsDeleted,
                        RoleId = customer.User.RoleId,
                    }
                };
                customerResponseModels.Add(customerResponseModel);
            }
            return customerResponseModels;
        }


        public CustomerResponseModel Update(CustomerResponseModel customer)
        {
            var custome = _customerRepository.GetById(customer.Data.Id);
            if (custome == null)
            {
                return null;
            }
            custome.FirstName = customer.Data.FirstName ?? custome.FirstName;
            custome.LastName = customer.Data.LastName ?? custome.LastName;
            custome.Modified = DateTime.Now;
            _customerRepository.Update(custome);
            return customer;

        }

        public UpdateCustomerPasswordRequestModel UpdatePassword(UpdateCustomerPasswordRequestModel customer)
        {
            //var custome = _customer.GetById(customer.StaffId);

            var user = _userRepository.GetById(customer.StaffId);
            if (user == null)
            {
                return null;
            }
            user.Password = customer.Password;
            user.Modified = DateTime.Now;
            _userRepository.Update(user);
            return customer;

        }
    }
}
