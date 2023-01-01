
using SMS_MVCDTO.Models.DTOs.AttendantDTOs;

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
        IEnumerable<AttendantResponseModel> GetByName(string name);
        IEnumerable<AttendantResponseModel> GetAttendants();
        AttendantResponseModel Update(AttendantResponseModel attendant);
        UpdateAttendantPasswordRequestModel UpdatePassword(UpdateAttendantPasswordRequestModel attendant);
        //UpdateAttendantRoleRequestModel UpdateRole(UpdateAttendantRoleRequestModel attendant);
        //bool IsActive(Attendant attendant);
    }
}
