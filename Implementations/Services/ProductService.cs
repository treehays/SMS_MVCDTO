using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.ProductDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        public ProductService(IProductRepository product)
        {
            _product = product;
        }

        public CreateProductRequestModel Create(CreateProductRequestModel product)
        {
            var produc = new Product
            {
                Barcode = product.Barcode,
                Name = product.Name,
                Category = product.Category,
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
            var produc = _product.GetAll();
            var products = new List<ProductResponseModel>();
            foreach (var product in produc)
            {
                var productResponseModel = new ProductResponseModel
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
                    }
                };
                products.Add(productResponseModel);
            }
            return products;
        }

        public IEnumerable<ProductResponseModel> GetByCategory(string productCategory)
        {
            var produc = _product.GetByCategory(productCategory);
            var products = new List<ProductResponseModel>();
            foreach (var product in produc)
            {
                var productResponseModel = new ProductResponseModel
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
                    }
                };
                products.Add(productResponseModel);
            }
            return products;

        }

        public ProductResponseModel GetById(string barCode)
        {
            var product = _product.GetById(barCode);
            if (product == null)
            {
                return null;
            }
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
                }
            };
            return produc;
        }

        public IEnumerable<ProductResponseModel> GetByName(string name)
        {
            var produc = _product.GetByName(name);
            var products = new List<ProductResponseModel>();
            foreach (var product in produc)
            {
                var productResponseModel = new ProductResponseModel
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
                    }
                };
                products.Add(productResponseModel);
            }
            return products;

        }

        //public IEnumerable<ProductResponseModel> GetByQuantityRemaining(int quantity)
        //{
        //    throw new NotImplementedException();
        //}

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

        public IEnumerable<ProductResponseModel> GetByQuantityRemaining(int quantity)
        {
            var produc = _product.GetByQuantityRemaining(quantity);
            var products = new List<ProductResponseModel>();
            foreach (var product in produc)
            {
                var productResponse = new ProductResponseModel
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
                    }
                };
                products.Add(productResponse);
            }
            return products;
        }
    }
}
