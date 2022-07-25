using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoBase;

namespace WebApplication1.RepositoryLayer.Repository.RepoCompany
{
    public interface ICompanyRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        public T GetByName(string name);
    }
}
