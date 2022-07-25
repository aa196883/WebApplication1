using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.ServiceLayer.Handlers.CompanyHandlers
{
    public class GetCompaniesHandler : IRequestHandler<GetCompaniesQuerry, IEnumerable<Company>>
    {
        private readonly ICompanyRepository<Company> _repository;

        public GetCompaniesHandler(ICompanyRepository<Company> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Company>> Handle(GetCompaniesQuerry request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAll());
        }
    }
}