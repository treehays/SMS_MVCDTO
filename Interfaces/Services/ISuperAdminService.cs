using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ISuperAdminService
    {
        SuperAdmin Create(SuperAdmin superAdmin);
        SuperAdmin Login(SuperAdmin superAdmin);
        void Delete(SuperAdmin superAdmin);
        SuperAdmin GetById(string staffId);
        SuperAdmin GetByEmail(string email);
        SuperAdmin GetByPhoneNumber(string phoneNumber);
        IList<SuperAdmin> GetByName(string name);
        IList<SuperAdmin> GetSuperAdmins();
        SuperAdmin Update(SuperAdmin superAdmin);
        SuperAdmin UpdatePassword(SuperAdmin superAdmin);
        SuperAdmin UpdateRole(SuperAdmin superAdmin);
        bool IsActive(SuperAdmin superAdmin);
    }
}
