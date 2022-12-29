using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationContext _context;
        public ProductCategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProductCategory Create(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
            return productCategory;
        }

        public void Delete(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
            _context.SaveChanges();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            var productCategory = _context.ProductCategories.Where(w => w.IsDeleted == false && w.IsActive == true);
            return productCategory;
        }

        public ProductCategory GetById(string categoryCode)
        {
            var productCategory = _context.ProductCategories.SingleOrDefault(x => x.CategoryCode == categoryCode);
            return productCategory;
        }

        //public bool IsAvailable(ProductCategory productCategory)
        //{

        //}

        public ProductCategory Update(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
            _context.SaveChanges();
            return productCategory;
        }
    }
}
