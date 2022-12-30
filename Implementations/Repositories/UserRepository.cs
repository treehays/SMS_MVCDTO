using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User GetById(string staffId)
        {
            var user = _context.Users.SingleOrDefault(x => x.StaffId == staffId);
            return user;
        }

        public User Login(User user)
        {
            var userr = _context.Users.SingleOrDefault(a => a.StaffId == user.StaffId && a.Password == user.Password);
            return userr;
        }

        public User UpdatePassword(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateRole(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
