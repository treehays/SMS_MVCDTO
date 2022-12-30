using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products.Where(s => s.IsAvailable == true && s.IsDeleted == false);
            return products;
        }

        public IEnumerable<Product> GetByCategory(string productCategory)
        {
            var products = _context.Products.Where(s => s.IsAvailable == true && s.IsDeleted == false);
            return products;
        }

        public Product GetById(string barCode)
        {
            var product = _context.Products.SingleOrDefault(a => a.IsDeleted == false && a.IsAvailable == true && a.Barcode == barCode);
            return product;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            var products = _context.Products.Where(a => a.IsAvailable == true && a.IsDeleted == false && name.All(b => a.Name.Contains(b)));
            return products;
        }

        public IEnumerable<Product> GetByQuantityRemaining(int quantity)
        {
            var products = _context.Products.Where(a => a.IsAvailable == true && a.IsDeleted == false && a.Quantity <= quantity);
            return products;
        }

        //public int InventoryQuantityAlert()
        //{
        //    var product
        //}

        //public bool IsAvailable(Product product)
        //{
        //    _context.Products.Update(product);
        //    _context.SaveChanges();
        //    return product;
        //}

        public Product RestockProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        //public Product UpdateProductQuantity(Product product)
        //{
        //    _context.Products.Update(product);
        //    _context.SaveChanges();
        //    return product;
        //}
    }
}
