using DataService;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
   public class DbSetContext : DbContext
    {
        public DbSetContext(DbContextOptions<DbSetContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
