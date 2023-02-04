using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Product Create(Product product);
        Product Update(Product product);
        void Delete(Product product);
        Product GetById(string barCode);
        IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetByCategory(string productCategory);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByQuantityRemaining(int quantity);
        Product RestockProduct(Product product);

        IEnumerable<Product> BelowReorderLevel();
        //Product UpdateProductQuantity(Product product);
        //int InventoryQuantityAlert();
        //bool IsAvailable(Product product);
    }
}
