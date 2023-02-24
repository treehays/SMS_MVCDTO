using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public CreateProductCategoryRequestModel Create(CreateProductCategoryRequestModel productCategory)
        {
            var productCategor = new ProductCategory
            {
                CategoryCode = Guid.NewGuid().ToString().ToUpper().Remove(6),
                Name = productCategory.Name,
                Description = productCategory.Description,
                Created = DateTime.Now,
                IsActive = true,
            };
            _productCategoryRepository.Create(productCategor);
            return productCategory;
        }

        public void Delete(string categoryCode)
        {
            var productCategory = _productCategoryRepository.GetById(categoryCode);
            if (productCategory != null)
            {
                productCategory.IsDeleted = true;
                _productCategoryRepository.Delete(productCategory);
            }
        }

        public IEnumerable<ProductCategoryResponseModel> GetAll()
        {
            var productCategories = _productCategoryRepository.GetAll();
            var productCategorie = new List<ProductCategoryResponseModel>();
            foreach (var productCategory in productCategories)
            {
                var productCategor = new ProductCategoryResponseModel
                {
                    Message = "Category retrieved successfully.",
                    Status = true,
                    Data = new ProductCategoryDTOs
                    {
                        CategoryCode = productCategory.CategoryCode,
                        Name = productCategory.Name,
                        Description = productCategory.Description,
                        IsActive = productCategory.IsActive,
                    }
                };
                productCategorie.Add(productCategor);
            }
            return productCategorie;
        }


        public ProductCategoryResponseModel GetById(string CategoryName)
        {
            var productCategory = _productCategoryRepository.GetById(CategoryName);
            if (productCategory != null)
            {
                var productCategor = new ProductCategoryResponseModel
                {
                    Message = "Category retrieved successfully.",
                    Status = true,
                    Data = new ProductCategoryDTOs
                    {
                        CategoryCode = productCategory.CategoryCode,
                        Name = productCategory.Name,
                        Description = productCategory.Description,
                        IsActive = productCategory.IsActive,
                    }
                };

                return productCategor;
            }
            return null;
        }

        public ProductCategoryResponseModel Update(ProductCategoryResponseModel productCategory)
        {
            var productCategor = _productCategoryRepository.GetById(productCategory.Data.CategoryCode);
            productCategor.Name = productCategory.Data.Name;
            productCategor.Description = productCategory.Data.Description;
            productCategor.Modified = DateTime.Now;
            _productCategoryRepository.Update(productCategor);
            return productCategory;

        }
    }
}
