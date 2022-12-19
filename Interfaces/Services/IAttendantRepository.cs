using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.DTOs.CustomerDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IAttendantService
    {
        CreateAttendantRequestModel Create(CreateAttendantRequestModel attendant);
        LoginRequestModel Login(LoginRequestModel user);
        void Delete(string staffId);
        Attendant GetById(string staffId);
        Attendant GetByEmail(string email);
        Attendant GetByPhoneNumber(string phoneNumber);
        IList<Attendant> GetByName(string name);
        IList<Attendant> GetAttendants();
        UpdateAttendantRequestModel Update(UpdateAttendantRequestModel attendant);
        UpdateAttendantPasswordRequestModel UpdatePassword(UpdateAttendantPasswordRequestModel attendant);
        UpdateAttendantRoleRequestModel UpdateRole(UpdateAttendantRoleRequestModel attendant);
        //bool IsActive(Attendant attendant);
    }
}
