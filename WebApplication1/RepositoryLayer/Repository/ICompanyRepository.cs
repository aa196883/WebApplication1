using WebApplication1.DomainLayer;

namespace WebApplication1.RepositoryLayer.Repository
{
    public interface ICompanyRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        public T Get(string name);
    }
}
