using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.ServiceLayer.Handlers.CompanyHandlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, Company>
    {
        private readonly ICompanyRepository<Company> _repository;

        public AddCompanyHandler(ICompanyRepository<Company> repository)
        {
            _repository = repository;
        }

        public Task<Company> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = request.company;
            _repository.Insert(company);
            return Task.FromResult(company);
        }
    }
}
