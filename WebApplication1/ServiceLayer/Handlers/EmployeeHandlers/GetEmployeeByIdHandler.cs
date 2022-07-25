using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

namespace WebApplication1.ServiceLayer.Handlers.EmployeeHandlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuerry, Employee>
    {
        private readonly IEmployeeRepository<Employee> _repository;

        public GetEmployeeByIdHandler(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        public Task<Employee> Handle(GetEmployeeByIdQuerry request, CancellationToken cancellationToken)
        {
            int id = request.id;
            Employee employee = _repository.GetByEmployeeId(id);
            return Task.FromResult(employee);
        }
    }
}
