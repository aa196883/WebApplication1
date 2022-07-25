﻿using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.ServiceLayer.Handlers.CompanyHandlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Company>
    {
        private readonly ICompanyRepository<Company> _repository;
        private readonly IMediator _mediator;

        public UpdateCompanyHandler(ICompanyRepository<Company> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company newCompany = request.company;
            Company oldCompany = _mediator.Send(new GetCompanyByNameQuerry(request.name)).Result;
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
