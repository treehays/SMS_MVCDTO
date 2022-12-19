using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IProductCategoryService
    {
        ProductCategory Create(ProductCategory productCategory);
        ProductCategory Update(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        IList<ProductCategory> GetAll();
        bool IsAvailable(ProductCategory productCategory);
    }
}
