
using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;

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
