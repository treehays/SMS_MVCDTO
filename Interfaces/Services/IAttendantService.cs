using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.DTOs.CustomerDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IAttendantService
    {
        CreateAttendantRequestModel Create(CreateAttendantRequestModel attendant);

        //LoginRequestModel Login(LoginRequestModel user);
        void Delete(string staffId);
        AttendantResponseModel GetById(string staffId);
        AttendantResponseModel GetByEmail(string email);
        AttendantResponseModel GetByPhoneNumber(string phoneNumber);
        IList<AttendantResponseModel> GetByName(string name);
        IList<AttendantResponseModel> GetAttendants();
        UpdateAttendantRequestModel Update(UpdateAttendantRequestModel attendant);
        UpdateAttendantPasswordRequestModel UpdatePassword(UpdateAttendantPasswordRequestModel attendant);
        UpdateAttendantRoleRequestModel UpdateRole(UpdateAttendantRoleRequestModel attendant);
        //bool IsActive(Attendant attendant);
    }
}
