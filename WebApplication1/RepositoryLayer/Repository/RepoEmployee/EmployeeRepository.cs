using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoBase;

namespace WebApplication1.RepositoryLayer.Repository.RepoEmployee
{
    public class EmployeeRepository<T> : RepositoryBase<T>, IEmployeeRepository<T> where T : Employee
    {
        public EmployeeRepository(IContext context) : base(context)
        {
        }

        public T GetByEmployeeId(int EmployeeId)
        {
            return entities.AsNoTracking().SingleOrDefault(x => x.EmployeeId == EmployeeId);
        }
    }
}
