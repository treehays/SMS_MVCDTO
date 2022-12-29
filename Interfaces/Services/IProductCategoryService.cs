using SMS_MVCDTO.DTOs.ProductCategoriesDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IProductCategoryService
    {
        CreateProductCategoryRequestModel Create(CreateProductCategoryRequestModel productCategory);
        UpdateProductCategoryRequestModel Update(UpdateProductCategoryRequestModel productCategory);
        void Delete(string categoryCode);
        IEnumerable<ProductCategoryResponseModel> GetAll();
        //bool IsAvailable(ProductCategory productCategory);
    }
}
