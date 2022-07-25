using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.ServiceLayer.Handlers.CompanyHandlers
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Company>
    {
        private readonly ICompanyRepository<Company> _repository;
        private readonly IMediator _mediator;

        public DeleteCompanyHandler(ICompanyRepository<Company> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<Company> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mediator.Send(new GetCompanyByNameQuerry(request.name)).Result;
            _repository.Delete(company);
            return Task.FromResult(company);
        }
    }
}
