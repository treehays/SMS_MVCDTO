using SMS_MVCDTO.Models.DTOs.SuperAdminDTOs;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ISuperAdminService
    {
        CreateSuperAdminRequestModel Create(CreateSuperAdminRequestModel superAdmin);
        //SuperAdmin Login(SuperAdmin superAdmin);
        void Delete(string staffId);
        SuperAdminResponseModel GetById(string staffId);
        SuperAdminResponseModel GetByEmail(string email);
        SuperAdminResponseModel GetByPhoneNumber(string phoneNumber);
        IEnumerable<SuperAdminResponseModel> GetByName(string name);
        IEnumerable<SuperAdminResponseModel> GetSuperAdmins();
        SuperAdminResponseModel Update(SuperAdminResponseModel superAdmin);
        //SuperAdmin UpdatePassword(SuperAdmin superAdmin);
        //SuperAdmin UpdateRole(SuperAdmin superAdmin);
        //bool IsActive(SuperAdmin superAdmin);
    }
}
