using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;

namespace WebApplication1.RepositoryLayer
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

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
