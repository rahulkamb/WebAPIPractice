using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Model;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
