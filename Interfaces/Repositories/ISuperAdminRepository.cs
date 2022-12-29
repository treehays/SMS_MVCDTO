using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ISuperAdminRepository
    {
        SuperAdmin Create(SuperAdmin superAdmin);
        //SuperAdmin Login(SuperAdmin superAdmin);
        void Delete(SuperAdmin superAdmin);
        SuperAdmin GetById(string staffId);
        SuperAdmin GetByEmail(string email);
        SuperAdmin GetByPhoneNumber(string phoneNumber);
        IEnumerable<SuperAdmin> GetByName(string name);
        IEnumerable<SuperAdmin> GetSuperAdmins();
        SuperAdmin Update(SuperAdmin superAdmin);
        //SuperAdmin UpdatePassword(SuperAdmin superAdmin);
        //SuperAdmin UpdateRole(SuperAdmin superAdmin);
        //bool IsActive(SuperAdmin superAdmin);
    }
}
