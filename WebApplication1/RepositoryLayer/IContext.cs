using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;


namespace WebApplication1.RepositoryLayer
{
    public interface IContext
    {
        DbSet<Employee>? Employees { get; set; }
        DbSet<Company>? Companies { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
