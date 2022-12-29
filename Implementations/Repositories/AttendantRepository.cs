using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

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
            _context.Attendants.Remove(attendant);
            _context.SaveChanges();
        }

        public IEnumerable<Attendant> GetAttendants()
        {
            var attendants = _context.Attendants.Where(w => w.IsDeleted == false && w.IsActive == true).ToList();
            //var attendants = _context.Attendants.Include(w => )
            return attendants;
        }

        public Attendant GetByEmail(string email)
        {
            var attendant = _context.Attendants.SingleOrDefault(w => w.Email == email);
            return attendant;
        }

        //To be fixed later
        public Attendant GetById(string staffId)
        {
            var attendant = _context.Attendants.SingleOrDefault(x => x.StaffId == staffId);
            //var attendant = _context.Attendants
            return attendant;
        }

        public IEnumerable<Attendant> GetByName(string name)
        {
            //var customer = _context.Customers.Include(m => m.Transactions).Where(x => name.All(y => (x.FirstName + x.LastName).Contains(y))).ToList();
            var attendants = _context.Attendants.Where(w => w.IsActive == true && w.IsDeleted == false && name.All(x => (w.LastName + w.FirstName).Contains(x)));
            return attendants;
        }

        public Attendant GetByPhoneNumber(string phoneNumber)
        {
            var attendant = _context.Attendants.SingleOrDefault(w => w.PhoneNumber == phoneNumber);
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
