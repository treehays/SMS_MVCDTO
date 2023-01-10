using System.Reflection.Metadata;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        public UserService(IUserRepository user)
        {
            _user = user;
        }

        public CreateUserRequestModel Create(CreateUserRequestModel user)
        {
            var userr = new User
            {
                Password = user.Password,
                StaffId = user.StaffId,
                Role = user.Role,
                Created = DateTime.Now,
            };
            _user.Create(userr);
            return user;
        }

        public void Delete(string staffId)
        {
            var user = _user.GetById(staffId);
            _user.Delete(user);
        }

        public UserResponseModel GetById(string staffId)
        {
            var user = _user.GetById(staffId);
            var userr = new UserResponseModel
            {
                Message = "User successfully retrieved.",
                Status = true,
                Data = new UserDTOs
                {
                    Password = user.Password,
                    StaffId = user.StaffId,
                    Role = user.Role,
                }
            };
            return userr;
        }


        public UserResponseModel Login(LoginRequestModel login)
        {

            var userr = new User
            {
                StaffId = login.StaffId,
                Password = login.Password,
            };
           
            var user = _user.Login(userr);
            if (user != null)
            {
                var userResponse = new UserResponseModel
                {
                    Message = "SUccesfull",
                    Status = true,
                    Data = new UserDTOs
                    {
                        StaffId = user.StaffId,
                        Password = user.Password,
                        Role = user.Role
                    }
                };
                return userResponse;
            }
            return null;
        }

        public UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel user)
        {
            var userr = _user.GetById(user.StaffId);
            userr.Password = user.Password ?? userr.Password;
            return user;
        }

        public UpdateUserRoleRequestModel UpdateRole(UpdateUserRoleRequestModel user)
        {
            var userr = _user.GetById(user.StaffId);
            userr.Role = user.Role;
            return user;
        }
    }
}
