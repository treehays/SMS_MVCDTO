﻿using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class SalesManagerRepository : ISalesManagerRepository
    {
        private readonly ApplicationContext _context;
        public SalesManagerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public SalesManager Create(SalesManager salesManager)
        {
            _context.SalesManagers.Add(salesManager);
            _context.SaveChanges();
            return salesManager;
        }

        public void Delete(SalesManager salesManager)
        {
            _context.SalesManagers.Update(salesManager);
            _context.SaveChanges();
        }

        public SalesManager GetByEmail(string email)
        {
            var salesManager = _context.SalesManagers.FirstOrDefault(s => s.User.Email == email);
            return salesManager;
        }

        public bool ExistByEmail(string email)
        {
            var salesManager = _context.SalesManagers.Any(s => s.User.Email == email);
            return salesManager;
        }

        public SalesManager GetById(string staffId)
        {
            var salesManager = _context.SalesManagers.Include(a => a.User).ThenInclude(b => b.BankDetail).SingleOrDefault(s => s.User.StaffId == staffId);
            return salesManager;
        }

        public IEnumerable<SalesManager> GetByName(string name)
        {
            var salesManagers = _context.SalesManagers.Where(s => !s.IsDeleted && s.User.IsActive && name.All(t => (s.User.LastName + s.User.FirstName).Contains(t)));
            return salesManagers;
        }

        public SalesManager GetByPhoneNumber(string phoneNumber)
        {
            var salesManager = _context.SalesManagers.SingleOrDefault(s => s.User.PhoneNumber == phoneNumber);
            return salesManager;
        }

        public IEnumerable<SalesManager> GetSalesManagers()
        {
            var salesManagers = _context.SalesManagers.Include(a => a.User).ThenInclude(b => b.BankDetail).Where(s => s.User.IsActive && !s.IsDeleted);
            return salesManagers;
        }

        public SalesManager Update(SalesManager salesManager)
        {
            _context.SalesManagers.Update(salesManager);
            _context.SaveChanges();
            return salesManager;
        }

        public SalesManager UpdatePassword(SalesManager salesManager)
        {
            _context.SalesManagers.Update(salesManager);
            _context.SaveChanges();
            return salesManager;
        }

        //public SalesManager UpdateRole(SalesManager salesManager)
        //{
        //    _context.SalesManagers.Update
        //}
    }
}
