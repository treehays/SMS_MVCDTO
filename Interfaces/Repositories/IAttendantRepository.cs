using SMS_MVCDTO.Models.Entities;
using System.Linq.Expressions;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IAttendantRepository
    {
        Attendant Create(Attendant attendant);
        //User Login(User user);
        void Delete(Attendant attendant);
        Attendant GetById(string id);
        Attendant Get(Expression<Func<Attendant, bool>> expression);
        Attendant GetByEmail(string email);
        Attendant GetByPhoneNumber(string phoneNumber);
        IEnumerable<Attendant> GetByName(string name);
        IEnumerable<Attendant> GetAttendants();
        Attendant Update(Attendant attendant);
        Attendant UpdatePassword(Attendant attendant);
        //Attendant UpdateRole(Attendant attendant);
        //bool IsActive(Attendant attendant);
    }
}
