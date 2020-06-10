using Microsoft.EntityFrameworkCore;
using Pallet.Models;

namespace Pallet.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {

        }
        // public DbSet<Employee> Employees { get; set; }

    }
}