using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

namespace WebApplication1.ServiceLayer.Handlers.EmployeeHandlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository<Employee> _repository;

        public AddEmployeeHandler(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        public Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = request.employee;
            _repository.Insert(employee);
            return Task.FromResult(employee);
        }
    }
}
