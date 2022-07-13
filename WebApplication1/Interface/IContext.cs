using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IContext
    {
        DbSet<Employee>? Employees { get; set; }

        int SaveChanges();
    }
}
