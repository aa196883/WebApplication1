﻿using MediatR;
using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.Queries.CompanyQueries
{
    public record AddCompanyCommand(Company company) : IRequest<Company>;
}
