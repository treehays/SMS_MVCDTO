using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesManager> SalesManagers { get; set; }
        public DbSet<Attendant> Attendants { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
