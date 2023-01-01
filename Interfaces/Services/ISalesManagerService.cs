
using SMS_MVCDTO.Models.DTOs.SalesManagerDTOs;
using SMS_MVCDTO.Models.DTOs.UserDTOs;

namespace SMS_MVCDTO.Interfaces.Services  
{
    public interface ISalesManagerService
    {
        CreateSalesManagerRequestModel Create(CreateSalesManagerRequestModel salesManager);
        //SalesManager Login(SalesManager salesManager);
        void Delete(string staffId);
        SalesManagerResponseModel GetById(string staffId);
        SalesManagerResponseModel GetByEmail(string email);
        SalesManagerResponseModel GetByPhoneNumber(string phoneNumber);
        IEnumerable<SalesManagerResponseModel> GetByName(string name);
        IEnumerable<SalesManagerResponseModel> GetSalesManagers();
        SalesManagerResponseModel Update (SalesManagerResponseModel salesManager);
        UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel salesManager);
        //SalesManager UpdateRole(SalesManager salesManager);
        //bool IsActive(SalesManager salesManager);
    }
}
