using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IAttendantRepository
    {
        Attendant Create(Attendant attendant);
        Attendant Login(Attendant attendant);
        void Delete(Attendant attendant);
        Attendant GetById(string staffId);
        Attendant GetByEmail(string email);
        Attendant GetPhoneNumber(string phoneNumber);
        IList<Attendant> GetByName(string name);
        IList<Attendant> GetAttendants();
        Attendant Update(Attendant attendant);
        Attendant UpdatePassword(Attendant attendant);
        Attendant UpdateRole(Attendant attendant);
        bool IsActive(Attendant attendant);
    }
}
