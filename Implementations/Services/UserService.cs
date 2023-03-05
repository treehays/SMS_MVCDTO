using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CreateUserRequestModel Create(CreateUserRequestModel user)
        {
            var userr = new User
            {
                Password = user.Password,
                StaffId = user.StaffId,
                RoleId = user.RoleId,
                Created = DateTime.Now,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            _userRepository.Create(userr);
            return user;
        }

        public void Delete(string staffId)
        {
            var user = _userRepository.GetById(staffId);
            _userRepository.Update(user);
        }

        public UserResponseModel GetById(string staffId)
        {
            var user = _userRepository.GetById(staffId);
            var userr = new UserResponseModel
            {
                Message = "User successfully retrieved.",
                Status = true,
                Data = new UserDTOs
                {
                    Password = user.Password,
                    StaffId = user.StaffId,
                    RoleId = user.RoleId,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
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

            var user = _userRepository.Login(userr);
            if (user != null)
            {
                var userResponse = new UserResponseModel
                {
                    Message = "SUccesfull",
                    Status = true,
                    Data = new UserDTOs
                    {
                        Id = user.Id,
                        StaffId = user.StaffId,
                        Password = user.Password,
                        RoleId = user.RoleId,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        ProfilePicture = user.ProfilePicture,
                        Name = user.FirstName,
                    }
                };
                return userResponse;
            }
            return null;
        }

        public UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel user)
        {
            var userr = _userRepository.GetById(user.StaffId);
            userr.Password = user.Password ?? userr.Password;
            _userRepository.Update(userr);
            return user;
        }

        public UpdateUserRoleRequestModel UpdateRole(UpdateUserRoleRequestModel user)
        {
            var userr = _userRepository.GetById(user.StaffId);
            userr.RoleId = user.RoleId;
            _userRepository.Update(userr);
            return user;
        }
    }
}
