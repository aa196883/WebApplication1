using WebApplication1.DomainLayer;

namespace WebApplication1.RepositoryLayer.Repository.RepoBase
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
        void SaveChanges();
    }
}
