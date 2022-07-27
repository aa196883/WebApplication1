using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoBase;

namespace WebApplication1.RepositoryLayer.Repository.RepoCompany
{
    public class CompanyRepository<T> : RepositoryBase<T>, ICompanyRepository<T> where T : BaseEntity
    {
        public CompanyRepository(IContext context) : base(context)
        {
        }
        public T? GetByName(string name)
        {
            var res = entities.AsNoTracking().SingleOrDefault(x => x.Name == name);
            return res;
        }
    }
}
