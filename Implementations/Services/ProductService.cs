using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        private readonly IProductCategoryRepository _productCategory;

        public ProductService(IProductRepository product, IProductCategoryRepository productCategory)
        {
            _product = product;
            _productCategory = productCategory;
        }

        public CreateProductRequestModel Create(CreateProductRequestModel product)
        {
            var produc = new Product
            {
                Barcode = product.Barcode,
                Name = product.Name,
                Category = product.Category,
                ProductCategoryId = product.Category,
                IsAvailable = true,
                Description = product.Description,
                SellingPrice = product.SellingPrice,
                Quantity = product.Quantity,
                ReorderLevel = product.ReorderLevel,
                Created = DateTime.Now,
            };
            _product.Create(produc);
            return product;
        }
        public int ReorderLevel { get; set; }

        public void Delete(string barCode)
        {
            var product = _product.GetById(barCode);
            if (product == null)
            {
                return;
            }
            product.IsDeleted = true;
            _product.Delete(product);
        }

        public IEnumerable<ProductResponseModel> GetAll()
        {
            var product = _product.GetAll();
            if (product == null)
            {
                return null;
            }
            var products = product.Select(item => new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Barcode = item.Barcode,
                    Name = item.Name,
                    Description = item.Description,
                    SellingPrice = item.SellingPrice,
                    Quantity = item.Quantity,
                    ReorderLevel = item.ReorderLevel,
                }
            }).ToList();
            return products;
        }

        public IEnumerable<ProductResponseModel> GetByCategory(string productCategory)
        {
            var product = _product.GetByCategory(productCategory);
            if (product == null)
            {
                return null;
            }
            var products = product.Select(item => new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Barcode = item.Barcode,
                    Name = item.Name,
                    Description = item.Description,
                    SellingPrice = item.SellingPrice,
                    Quantity = item.Quantity,
                    ReorderLevel = item.ReorderLevel,
                }
            }).ToList();
            return products;

        }

        public ProductResponseModel GetById(string barCode)
        {
            var product = _product.GetById(barCode);
            if (product == null)
            {
                return null;
            }
            string categoryName = null;
            var category = _productCategory.GetById(product.Category);
            //if (category == null) { categoryName = category.Name; }
            var produc = new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Barcode = product.Barcode,
                    Name = product.Name,
                    Description = product.Description,
                    SellingPrice = product.SellingPrice,
                    Quantity = product.Quantity,
                    ReorderLevel = product.ReorderLevel,
                    Category = category.Name,
                }
            };
            return produc;
        }

        public IEnumerable<ProductResponseModel> GetByName(string name)
        {
            var product = _product.GetByName(name);
            if (product == null)
            {
                return null;
            }
            var products = product.Select(item => new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Barcode = item.Barcode,
                    Name = item.Name,
                    Description = item.Description,
                    SellingPrice = item.SellingPrice,
                    Quantity = item.Quantity,
                    ReorderLevel = item.ReorderLevel,
                }
            }).ToList();
            return products;

        }

        public RestockProductRequestModel RestockProduct(RestockProductRequestModel product)
        {
            var produc = _product.GetById(product.Barcode);
            if (produc == null)
            {
                return null;
            }
            if (produc.Quantity < 0)
            {
                return product;
            }
            produc.Quantity = product.Quantity + produc.Quantity;
            _product.RestockProduct(produc);
            return product;
        }

        public ProductResponseModel Update(ProductResponseModel product)
        {
            var produc = _product.GetById(product.Data.Barcode);
            produc.SellingPrice = product.Data.SellingPrice;
            produc.Name = product.Data.Name ?? produc.Name;
            produc.Description = product.Data.Description ?? produc.Description;
            produc.ReorderLevel = product.Data.ReorderLevel;
            _product.Update(produc);
            return product;
        }

        //public ProductResponseModel Update(ProductResponseModel product)
        //{
        //    var produc = _product.GetById(product.Data.Barcode);
        //    produc.SellingPrice = product.Data.SellingPrice;
        //    produc.Name = product.Data.Name ?? produc.Name;
        //    produc.Description = product.Data.Description ?? produc.Description;
        //    produc.ReorderLevel = product.Data.ReorderLevel;
        //    _product.Update(produc);
        //    return product;
        //}

        public IEnumerable<ProductResponseModel> GetByQuantityRemaining(int quantity)
        {
            var product = _product.GetByQuantityRemaining(quantity);
            if (product == null)
            {
                return null;
            }
            var products = product.Select(item => new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Barcode = item.Barcode,
                    Name = item.Name,
                    Description = item.Description,
                    SellingPrice = item.SellingPrice,
                    Quantity = item.Quantity,
                    ReorderLevel = item.ReorderLevel,
                }
            }).ToList();
            return products;
        }

        public IEnumerable<ProductResponseModel> BelowReorderLevel()
        {
            var product = _product.BelowReorderLevel();
            if (product == null)
            {
                return null;
            }
            var products = product.Select(item => new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Barcode = item.Barcode,
                    Name = item.Name,
                    Description = item.Description,
                    SellingPrice = item.SellingPrice,
                    Quantity = item.Quantity,
                    ReorderLevel = item.ReorderLevel,
                }
            }).ToList();
            return products;
        }
    }
}
