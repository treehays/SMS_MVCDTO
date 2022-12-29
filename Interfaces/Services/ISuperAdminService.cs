﻿using SMS_MVCDTO.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ISuperAdminService
    {
        CreateSuperAdminRequestModel Create(CreateSuperAdminRequestModel superAdmin);
        //SuperAdmin Login(SuperAdmin superAdmin);
        void Delete(string staffId);
        SuperAdminResponseModel GetById(string staffId);
        SuperAdminResponseModel GetByEmail(string email);
        SuperAdminResponseModel GetByPhoneNumber(string phoneNumber);
        IEnumerable<SuperAdminResponseModel> GetByName(string name);
        IEnumerable<SuperAdminResponseModel> GetSuperAdmins();
        UpdateSuperAdminRequestModel Update(UpdateSuperAdminRequestModel superAdmin);
        //SuperAdmin UpdatePassword(SuperAdmin superAdmin);
        //SuperAdmin UpdateRole(SuperAdmin superAdmin);
        //bool IsActive(SuperAdmin superAdmin);
    }
}
