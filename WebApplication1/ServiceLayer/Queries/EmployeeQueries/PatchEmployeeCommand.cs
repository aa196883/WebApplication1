using MediatR;
using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.Queries.EmployeeQueries
{
    public record PatchEmployeeCommand(Employee employee, int id) : IRequest<Employee>;
}
