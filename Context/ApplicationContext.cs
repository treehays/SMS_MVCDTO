using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
