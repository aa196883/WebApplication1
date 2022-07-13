using Microsoft.EntityFrameworkCore;
using WebApplication1.Interface;

namespace WebApplication1.Models
{
    public class Context : DbContext, IContext
    {
        public DbSet<Employee>? Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=test;Integrated Security=True");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
