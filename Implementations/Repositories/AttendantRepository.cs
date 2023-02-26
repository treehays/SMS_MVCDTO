using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;
using System.Linq.Expressions;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class AttendantRepository : IAttendantRepository
    {
        private readonly ApplicationContext _context;
        public AttendantRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Attendant Create(Attendant attendant)
        {
            _context.Attendants.Add(attendant);
            _context.SaveChanges();
            return attendant;
        }

        public void Delete(Attendant attendant)
        {
            _context.Attendants.Update(attendant);
            _context.SaveChanges();
        }

        public IEnumerable<Attendant> GetAttendants()
        {
            var attendants = _context.Attendants.Where(w => !w.IsDeleted && w.User.IsActive).ToList();
            //var attendants = _context.Attendants.Include(w => )
            return attendants;
        }

        public Attendant Get(Expression<Func<Attendant, bool>> expression)
        {
            var attendant = _context.Attendants.SingleOrDefault(expression);
            return attendant;
        }

        public Attendant GetByEmail(string email)
        {
            var attendant = _context.Attendants.SingleOrDefault(w => w.User.Email.ToLower() == email.ToLower());
            return attendant;
        }

        //To be fixed later
        public Attendant GetById(int id)
        {
            //bool emailExists = _context.Attendants.Any(x => x.StaffId == staffId.ToLower());
            var attendant = _context.Attendants.SingleOrDefault(x => x.UserId == id);
            if (attendant == null)
            {
                return null;
            }
            return attendant;
        }

        public IEnumerable<Attendant> GetByName(string name)
        {

            var attendants = _context.Attendants.AsEnumerable().Where(w => w.User.IsActive && !w.IsDeleted && name.Any(x => (w.FirstName + w.LastName).ToLower().Contains(x.ToString().ToLower())));
            return attendants;
        }

        public Attendant GetByPhoneNumber(string phoneNumber)
        {
            var attendant = _context.Attendants.SingleOrDefault(w => w.User.PhoneNumber == phoneNumber);
            return attendant;
        }

        //public bool IsActive(Attendant attendant)
        //{
        //    var attendant = _context.
        //    //var attendant = _context.Attendants.Any(w => w.IsActive == true);
        //    return attendant;
        //}

        //public bool IsAdmin(UserRole userRole)
        //{
        //    var isAdmin = userRole == UserRole.Admin || userRole == UserRole.SuperAdmin;
        //    return isAdmin;
        //}

        //public User Login(User user)
        //{
        //    var userLogin = _context.Users.SingleOrDefault(w => w.StaffId == user.StaffId && w.Password == user.Password);
        //    return userLogin;
        //}

        public Attendant Update(Attendant attendant)
        {
            _context.Attendants.Update(attendant);
            _context.SaveChanges();
            return attendant;
        }

        public Attendant UpdatePassword(Attendant attendant)
        {
            _context.Attendants.Update(attendant);
            _context.SaveChanges();
            return attendant;
        }

        //public Attendant UpdateRole(Attendant attendant)
        //{
        //    _context.Attendants.Update(attendant);
        //    _context.SaveChanges();
        //    return attendant;
        //}
    }
}
