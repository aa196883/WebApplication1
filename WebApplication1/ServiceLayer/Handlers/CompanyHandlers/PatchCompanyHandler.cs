using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.ServiceLayer.Handlers.CompanyHandlers
{
    public class PatchCompanyHandler : IRequestHandler<PatchCompanyCommand, Company>
    {
        private readonly ICompanyRepository<Company> _repository;
        private readonly IMediator _mediator;

        public PatchCompanyHandler(ICompanyRepository<Company> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<Company> Handle(PatchCompanyCommand request, CancellationToken cancellationToken)
        {
            Company newCompany = request.company;
            Company oldCompany = _mediator.Send(new GetCompanyByNameQuery(request.name)).Result;
            if (newCompany.Name == null)
            {
                newCompany.Name = oldCompany.Name;
            }
            newCompany.Id = oldCompany.Id;
            _repository.Update(newCompany);
            return Task.FromResult(newCompany);
        }
    }
}
