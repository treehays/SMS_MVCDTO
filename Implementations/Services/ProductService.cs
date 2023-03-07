using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public CreateProductRequestModel Create(CreateProductRequestModel product)
        {
            var produc = new Product
            {
                Barcode = product.Barcode,
                Name = product.Name,
                ProductCategoryId = product.CategoryId,
                IsAvailable = true,
                Description = product.Description,
                SellingPrice = product.SellingPrice,
                Quantity = product.Quantity,
                ReorderLevel = product.ReorderLevel,
                Created = DateTime.Now,
                PicturPath = product.PicturePath,

            };
            _productRepository.Create(produc);
            return product;
        }
        public int ReorderLevel { get; set; }



        public void Delete(string id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return;
            }
            product.IsDeleted = true;
            _productRepository.Delete(product);
        }

        public IEnumerable<ProductResponseModel> GetAll()
        {
            var product = _productRepository.GetAll();
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
                    Id = item.Id,
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

        public IEnumerable<ProductResponseModel> GetByCategory(string productCategoryId)
        {
            var product = _productRepository.GetByCategory(productCategoryId);
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

        public ProductResponseModel GetById(string id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            //string categoryName = null;
            //var category = _productCategoryRepository.GetById(product.ProductCategoryId);
            //if (category == null) { categoryName = category.Name; }
            var produc = new ProductResponseModel
            {
                Message = "product retrieved successfully.",
                Status = true,
                Data = new ProductDTOs
                {
                    Id = product.Id,
                    Barcode = product.Barcode,
                    Name = product.Name,
                    Description = product.Description,
                    SellingPrice = product.SellingPrice,
                    Quantity = product.Quantity,
                    ReorderLevel = product.ReorderLevel,
                    Category = product.ProductCategory.Name,
                }
            };
            return produc;
        }


        public ProductResponseModel GetByBarCode(string barCode)
        {
            var product = _productRepository.GetByBarCode(barCode);
            if (product == null)
            {
                return null;
            }
            //string categoryName = null;
            //if (category == null) { categoryName = category.Name; }
            //var category = _productCategoryRepository.GetById(product.ProductCategoryId);
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
                    Category = product.ProductCategory.Name,
                }
            };
            return produc;
        }

        public IEnumerable<ProductResponseModel> GetByName(string name)
        {
            var product = _productRepository.GetByName(name);
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
            var produc = _productRepository.GetById(product.Id);
            if (produc == null)
            {
                return null;
            }
            if (produc.Quantity < 0)
            {
                return product;
            }
            produc.Quantity = product.Quantity + produc.Quantity;
            _productRepository.RestockProduct(produc);
            return product;
        }

        public ProductResponseModel Update(ProductResponseModel product)
        {
            var produc = _productRepository.GetById(product.Data.Id);
            produc.SellingPrice = product.Data.SellingPrice;
            produc.Name = product.Data.Name ?? produc.Name;
            produc.Description = product.Data.Description ?? produc.Description;
            produc.ReorderLevel = product.Data.ReorderLevel;
            _productRepository.Update(produc);
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
            var product = _productRepository.GetByQuantityRemaining(quantity);
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
            var product = _productRepository.BelowReorderLevel();
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
