using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Context
{
    public class AnotherSeedWay
    {
        public static void InitializeDb(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {

                context.Database.Migrate();
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new List<Role>()
                    {
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
                        },
                    });
                    context.SaveChanges();
                }


                if (!context.Users.Any())
                {
                    context.Users.Add(new User()
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

                    });
                    context.SaveChanges();
                }


                if (!context.SuperAdmins.Any())
                {
                    context.SuperAdmins.Add(new SuperAdmin()
                    {
                        Id = "1",
                        UserId = "1",
                        DateOfBirth = DateTime.Now,
                        Gender = Enums.GenderType.Male,
                        MaritalStatus = Enums.MaritalStatusType.Married,
                        Created = DateTime.Now,
                        IsDeleted = false,
                        Modified = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
