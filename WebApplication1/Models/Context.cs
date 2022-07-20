using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Interface;

namespace WebApplication1.Models
{
    public class Context : DbContext, IContext
    {
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Company>? Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=test;Integrated Security=True");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public override EntityEntry Entry(Object Entry)
        {
            return base.Entry(Entry);
        }

    }
}
