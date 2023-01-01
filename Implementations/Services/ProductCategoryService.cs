using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategory;
        public ProductCategoryService(IProductCategoryRepository productCategory)
        {
            _productCategory = productCategory;
        }

        public CreateProductCategoryRequestModel Create(CreateProductCategoryRequestModel productCategory)
        {
            var productCategor = new ProductCategory
            {
                CategoryCode = Guid.NewGuid().ToString().ToUpper().Remove(6),
                Name = productCategory.Name,
                Description = productCategory.Description,
                Created = DateTime.Now,
            };
            _productCategory.Create(productCategor);
            return productCategory;
        }

        public void Delete(string categoryCode)
        {
            var productCategory = _productCategory.GetById(categoryCode);
            _productCategory.Delete(productCategory);
        }

        public IEnumerable<ProductCategoryResponseModel> GetAll()
        {
            var productCategories = _productCategory.GetAll();
            var productCategorie = new List<ProductCategoryResponseModel>();
            foreach (var productCategory in productCategories)
            {
                var productCategor = new ProductCategoryResponseModel
                {
                    Message = "Category retrieved successfully.",
                    Status = true,
                    Data = new ProductCategoryDTOs
                    {
                        Name = productCategory.Name,
                        Description = productCategory.Description,
                        IsActive = productCategory.IsActive,
                    }
                };
            }
            return productCategorie;
        }

        public UpdateProductCategoryRequestModel Update(UpdateProductCategoryRequestModel productCategory)
        {
            var productCategor = _productCategory.GetById(productCategory.CategoryCode);
            productCategor.Name = productCategory.Name;
            productCategor.Description = productCategory.Description;
            productCategor.Modified = DateTime.Now;
            return productCategory;

        }
    }
}
