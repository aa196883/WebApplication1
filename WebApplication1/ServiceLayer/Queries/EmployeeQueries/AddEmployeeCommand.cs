using MediatR;
using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.Queries.EmployeeQueries
{
    public record AddEmployeeCommand(Employee employee) : IRequest<Employee>;
}
