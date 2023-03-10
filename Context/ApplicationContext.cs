using BCrypt.Net;
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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(

                new Role
                {
                    Id = "1",
                    RoleName = "SuperAdmin",
                    RoleDescription = "Staff",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    Modified = DateTime.Now,
                },
                new Role
                {
                    Id = "2",
                    RoleName = "SalesManager",
                    RoleDescription = "Staff",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    Modified = DateTime.Now,
                },
                new Role
                {
                    Id = "3",
                    RoleName = "Attendant",
                    RoleDescription = "Staff",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    Modified = DateTime.Now,
                },
                new Role
                {
                    Id = "4",
                    RoleName = "Customer",
                    RoleDescription = "Staff",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    Modified = DateTime.Now,
                }
                );


            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = "1",
                        StaffId = "SUP001",
                        FirstName = "Abdulsuper",
                        LastName = "Salamsuper",
                        Password = BCrypt.Net.BCrypt.HashPassword("SUP001", SaltRevision.Revision2B),
                        RoleId = "1",
                        Email = "aymoneyay@gmail.com",
                        PhoneNumber = "08066117783",
                        IsActive = true,
                        Created = DateTime.Now,
                        IsDeleted = false,
                    }
                );


            modelBuilder.Entity<SuperAdmin>()
                .HasData(
                    new SuperAdmin
                    {
                        Id = "1",
                        UserId = "1",
                        DateOfBirth = DateTime.Now,
                        Gender = Enums.GenderType.Male,
                        MaritalStatus = Enums.MaritalStatusType.Married,
                        Created = DateTime.Now,
                        IsDeleted = false,
                        Modified = DateTime.Now,
                    }
                );

        }

    }
}
