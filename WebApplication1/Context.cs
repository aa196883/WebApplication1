using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Context : DbContext
    {
        DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sdworx\Documents\Employees.mdf;Integrated Security=True;Connect Timeout=30");

        }
    }
}
