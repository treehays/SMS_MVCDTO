using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAttendants()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetById(string staffId)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public User GetPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetSalesManagers()
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool IsActive(User user)
        {
            throw new NotImplementedException();
        }

        public User Login(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdatePassword(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateRole(User user)
        {
            throw new NotImplementedException();
        }
    }
}
