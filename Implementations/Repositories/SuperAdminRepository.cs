﻿using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class SuperAdminRepository : ISuperAdminRepository
    {
        private readonly ApplicationContext _context;
        public SuperAdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public SuperAdmin Create(SuperAdmin superAdmin)
        {
            _context.SuperAdmins.Add(superAdmin);
            _context.SaveChanges();
            //_context.Entry(superAdmin).State = EntityState.Added;
            return superAdmin;
        }

        //public void Delete(SuperAdmin superAdmin)
        //{
        //    //_context.SuperAdmins.Update(superAdmin);
        //    _context.SaveChanges();
        //}

        public SuperAdmin GetByEmail(string email)
        {
            var superAdmin = _context.SuperAdmins.SingleOrDefault(s => s.User.Email == email);
            return superAdmin;
        }

        public bool EmailExist(string email)
        {
            var emailExist = _context.SuperAdmins.Any(s => s.User.Email == email);
            return emailExist;
        }

        public SuperAdmin GetById(string staffId)
        {
            var superAdmin = _context.SuperAdmins.SingleOrDefault(s => s.User.StaffId == staffId);
            return superAdmin;
        }

        public IEnumerable<SuperAdmin> GetByName(string name)
        {
            var superAdmins = _context.SuperAdmins.Where(w => w.User.IsActive && !w.IsDeleted && name.All(x => (w.User.FirstName + w.User.LastName).Contains(x)));
            return superAdmins;
        }

        public SuperAdmin GetByPhoneNumber(string phoneNumber)
        {
            var superAdmin = _context.SuperAdmins.SingleOrDefault(w => w.User.PhoneNumber == phoneNumber);
            return superAdmin;
        }

        public IEnumerable<SuperAdmin> GetSuperAdmins()
        {
            var superAdmins = _context.SuperAdmins.Include(a => a.User).ThenInclude(b => b.Role).Where(w => w.User.IsActive && !w.IsDeleted);
            return superAdmins;
        }

        //public bool IsActive(SuperAdmin superAdmin)
        //{
        //    throw new NotImplementedException();
        //}

        public SuperAdmin Update(SuperAdmin superAdmin)
        {
            //_context.SuperAdmins.Update(superAdmin);
            _context.SaveChanges();
            return superAdmin;
        }

        //public SuperAdmin UpdatePassword(SuperAdmin superAdmin)
        //{
        //    throw new NotImplementedException();
        //}

        //public SuperAdmin UpdateRole(SuperAdmin superAdmin)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
