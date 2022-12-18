using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class ProductService : IProductService
    {
        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetByCategory(string productCategory)
        {
            throw new NotImplementedException();
        }

        public Product GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetByQuantityRemaining(int quantity)
        {
            throw new NotImplementedException();
        }

        public int InventoryQuantityAlert()
        {
            throw new NotImplementedException();
        }

        public bool IsAvailable(Product product)
        {
            throw new NotImplementedException();
        }

        public Product RestockProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProductQuantity(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
