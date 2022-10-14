using CRUD_V6_MVCCore_Middleware.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_V6_MVCCore_Middleware.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
