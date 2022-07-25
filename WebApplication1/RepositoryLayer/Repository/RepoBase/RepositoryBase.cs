using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;

namespace WebApplication1.RepositoryLayer.Repository.RepoBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly IContext _context;
        protected readonly DbSet<T> entities;

        public RepositoryBase(IContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return entities.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
