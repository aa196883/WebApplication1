using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

namespace WebApplication1.ServiceLayer.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository<Employee> _repository;
        private readonly IMediator _mediator;

        public DeleteEmployeeHandler(IEmployeeRepository<Employee> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<Employee> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _mediator.Send(new GetEmployeeByIdQuerry(request.id)).Result;
            _repository.Delete(employee);
            return Task.FromResult(employee);
        }
    }
}
