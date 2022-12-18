﻿using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        ProductCategory Create(ProductCategory productCategory);
        ProductCategory Update(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        IList<ProductCategory> GetAll();
        bool IsAvailable(ProductCategory productCategory);
    }
}