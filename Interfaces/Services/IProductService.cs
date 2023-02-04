using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IProductService
    {
        CreateProductRequestModel Create(CreateProductRequestModel product);
        ProductResponseModel Update(ProductResponseModel product);
        void Delete(string barCode);
        ProductResponseModel GetById(string barCode);
        IEnumerable<ProductResponseModel> GetByName(string name);
        IEnumerable<ProductResponseModel> GetByCategory(string productCategory);
        IEnumerable<ProductResponseModel> GetAll();
        IEnumerable<ProductResponseModel> GetByQuantityRemaining(int quantity);
        RestockProductRequestModel RestockProduct(RestockProductRequestModel product);
        IEnumerable<ProductResponseModel> BelowReorderLevel();

    }
}
