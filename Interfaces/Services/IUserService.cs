using SMS_MVCDTO.DTOs.UserDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IUserService
    {
        CreateUserRequestModel Create(CreateUserRequestModel user);
        LoginRequestModel Login(LoginRequestModel user);
        void Delete(string staffId);
        UserResponseModel GetById(string staffId);
        UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel user);
        UpdateUserRoleRequestModel UpdateRole(UpdateUserRoleRequestModel user);
    }
}
