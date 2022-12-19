using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IAttendantService
    {
        Attendant Create(Attendant attendant);
        User Login(User user);
        void Delete(Attendant attendant);
        Attendant GetById(string staffId);
        Attendant GetByEmail(string email);
        Attendant GetByPhoneNumber(string phoneNumber);
        IList<Attendant> GetByName(string name);
        IList<Attendant> GetAttendants();
        Attendant Update(Attendant attendant);
        Attendant UpdatePassword(Attendant attendant);
        Attendant UpdateRole(Attendant attendant);
        //bool IsActive(Attendant attendant);
    }
}
