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
            var products = _context.Products.Where(s => s.IsAvailable && !s.IsDeleted);
            return products;
        }


        public IEnumerable<Product> BelowReorderLevel()
        {
            var product = _context.Products.Where(x => x.ReorderLevel >= x.Quantity && x.IsAvailable && !x.IsDeleted);
            return product;
        }


        public IEnumerable<Product> GetByCategory(string productCategory)
        {
            var products = _context.Products.Where(s => s.IsAvailable && !s.IsDeleted);
            return products;
        }

        public Product GetById(string barCode)
        {
            var product = _context.Products.SingleOrDefault(a => !a.IsDeleted && a.IsAvailable && a.Barcode.ToLower() == barCode.ToLower());
            return product;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            var products = _context.Products.AsEnumerable().Where(a => a.IsAvailable && !a.IsDeleted && name.All(b => a.Name.ToLower().Contains(b.ToString().ToLower())));
            return products;
        }

        public IEnumerable<Product> GetByQuantityRemaining(int quantity)
        {
            var products = _context.Products.Where(a => a.IsAvailable && !a.IsDeleted && a.Quantity <= quantity);
            return products;
        }

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

    }
}
