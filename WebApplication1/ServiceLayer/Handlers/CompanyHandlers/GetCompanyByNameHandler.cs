using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.ServiceLayer.Handlers.CompanyHandlers
{
    public class GetCompanyByNameHandler : IRequestHandler<GetCompanyByNameQuerry, Company>
    {
        private readonly ICompanyRepository<Company> _repository;

        public GetCompanyByNameHandler(ICompanyRepository<Company> repository)
        {
            _repository = repository;
        }

        public Task<Company> Handle(GetCompanyByNameQuerry request, CancellationToken cancellationToken)
        {
            string name = request.name;
            try
            {
                Company company = _repository.GetByName(name);
                return Task.FromResult(company);
            }catch(InvalidOperationException e){
                throw e;
            }
            
        }
    }
}
