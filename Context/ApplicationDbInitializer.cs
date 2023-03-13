using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
//using sib_api_v3_sdk.Model;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Context
{
    public class ApplicationDbInitializer
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
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
                    context.Users.AddRange(new List<User>()
                    {
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
                    });
                    context.SaveChanges();
                }


                if (!context.SuperAdmins.Any())
                {
                    context.SuperAdmins.AddRange(new List<SuperAdmin>()
                    {
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
                    });
                    context.SaveChanges();
                }

            }
        }

    }
}
