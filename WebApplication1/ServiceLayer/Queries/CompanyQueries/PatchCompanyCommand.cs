using MediatR;
using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.Queries.CompanyQueries
{
    public record PatchCompanyCommand(Company company, string name) : IRequest<Company>;
}
