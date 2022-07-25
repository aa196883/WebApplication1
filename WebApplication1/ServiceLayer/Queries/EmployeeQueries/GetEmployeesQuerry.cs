using MediatR;
using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.Queries.EmployeeQueries
{
    public record GetEmployeesQuerry : IRequest<IEnumerable<Employee>>;
}
