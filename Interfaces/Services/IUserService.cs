using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IUserService
    {
        User Create(User user);
        User Login(User user);
        void Delete(User user);
        User GetById(string staffId);
        IList<User> GetUsers();
        IList<User> GetAttendants();
        IList<User> GetSalesManagers();
        //IList<User> GetUsers();
        User Update(User user);
        User UpdatePassword(User user);
        User UpdateRole(User user);
        bool IsActive(User user);

    }
}
