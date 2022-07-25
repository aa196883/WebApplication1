using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;

namespace WebApplication1.ServiceLayer.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository<Employee> _repository;

        public EmployeeService(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = this.GetEmployee(id);
            _repository.Delete(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return _repository.GetByEmployeeId(id);
        }

        public Employee InsertEmployee(Employee employee)
        {
            _repository.Insert(employee);
            return employee;
        }

        public Employee PatchEmployee(int id, Employee newEmployee)
        {
            Employee oldEmployee = this.GetEmployee(id);
            if(newEmployee.Name == null)
            {
                newEmployee.Name = oldEmployee.Name;
            }
            if(newEmployee.EmployeeId == 0)
            {
                newEmployee.EmployeeId = oldEmployee.EmployeeId;
            }
            newEmployee.Id = oldEmployee.Id;
            _repository.Update(newEmployee);
            return newEmployee;
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            int id_ = this.GetEmployee(id).Id;
            employee.Id = id_;
            _repository.Update(employee);
            return employee;
        }
    }
}
