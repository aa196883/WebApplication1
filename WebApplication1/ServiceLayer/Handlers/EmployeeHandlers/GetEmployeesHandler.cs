using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

namespace WebApplication1.ServiceLayer.Handlers.EmployeeHandlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuerry, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository<Employee> _repository;

        public GetEmployeesHandler(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Employee>> Handle(GetEmployeesQuerry request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAll());
        }
    }
}