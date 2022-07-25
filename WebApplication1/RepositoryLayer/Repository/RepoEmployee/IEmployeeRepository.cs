using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoBase;

namespace WebApplication1.RepositoryLayer.Repository.RepoEmployee
{
    public interface IEmployeeRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        public T GetByEmployeeId(int EmployeeId);
    }
}
