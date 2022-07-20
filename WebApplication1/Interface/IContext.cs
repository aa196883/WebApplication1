using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication1.Interface
{
    public interface IContext
    {
        DbSet<Employee>? Employees { get; set; }
        DbSet<Company>? Companies { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        EntityEntry Entry(Object Entry);
    }
}
