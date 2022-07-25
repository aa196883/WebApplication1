using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;

namespace WebApplication1.RepositoryLayer.Repository
{
    public class CompanyRepository<T> : RepositoryBase<T>, ICompanyRepository<T> where T : BaseEntity
    {
        public CompanyRepository(IContext context) : base(context)
        {
        }
        public T Get(string name)
        {
            return entities.AsNoTracking().SingleOrDefault(x => x.Name == name);
        }
    }
}
