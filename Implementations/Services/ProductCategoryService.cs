using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
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
                IsActive = true,
            };
            _productCategory.Create(productCategor);
            return productCategory;
        }

        public void Delete(string categoryCode)
        {
            var productCategory = _productCategory.GetById(categoryCode);
            if (productCategory != null)
            {
                productCategory.IsDeleted = true;
                _productCategory.Delete(productCategory);
            }
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
            var productCategory = _productCategory.GetById(CategoryName);
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
            var productCategor = _productCategory.GetById(productCategory.Data.CategoryCode);
            productCategor.Name = productCategory.Data.Name;
            productCategor.Description = productCategory.Data.Description;
            productCategor.Modified = DateTime.Now;
            _productCategory.Update(productCategor);
            return productCategory;

        }
    }
}
