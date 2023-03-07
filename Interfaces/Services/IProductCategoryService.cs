
using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IProductCategoryService
    {
        CreateProductCategoryRequestModel Create(CreateProductCategoryRequestModel productCategory);
        ProductCategoryResponseModel Update(ProductCategoryResponseModel productCategory);
        void Delete(string categoryCode);
        IEnumerable<ProductCategoryResponseModel> GetAll();
        ProductCategoryResponseModel GetById(string categoryCode);
    }
}
