using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface ISalesManagerRepository
    {
        SalesManager Create(SalesManager salesManager);
        SalesManager Login(SalesManager salesManager);
        void Delete(SalesManager salesManager);
        SalesManager GetById(string staffId);
        SalesManager GetByEmail(string email);
        SalesManager GetPhoneNumber(string phoneNumber);
        IList<SalesManager> GetByName(string name);
        IList<SalesManager> GetSalesManagers();
        SalesManager Update(SalesManager salesManager);
        SalesManager UpdatePassword(SalesManager salesManager);
        SalesManager UpdateRole(SalesManager salesManager);
        bool IsActive(SalesManager salesManager);
    }
}
