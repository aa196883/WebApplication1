using MediatR;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

namespace WebApplication1.ServiceLayer.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository<Employee> _repository;
        private readonly IMediator _mediator;

        public UpdateEmployeeHandler(IEmployeeRepository<Employee> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee newEmployee = request.employee;
            Employee oldEmployee = _mediator.Send(new GetEmployeeByIdQuerry(request.id)).Result;
            if (newEmployee.Name == null)
            {
                newEmployee.Name = oldEmployee.Name;
            }
            if (newEmployee.EmployeeId == 0)
            {
                newEmployee.EmployeeId = oldEmployee.EmployeeId;
            }
            newEmployee.Id = oldEmployee.Id;
            _repository.Update(newEmployee);
            return Task.FromResult(newEmployee);
        }
    }
}
