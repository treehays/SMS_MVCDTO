using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User Login(User user);
        User Update(User user);
        User GetById(string staffId);
        bool SendEmail(string email, string OTPKey);
        //  void Delete(User user);
        //IEnumerable<User> GetUsers();
        //IEnumerable<User> GetAttendants();
        //IEnumerable<User> GetSalesManagers();
        //IList<User> GetUsers();
        //User Update(User user);
        //  User UpdateRole(User user);
        //bool IsActive(User user);

    }
}
