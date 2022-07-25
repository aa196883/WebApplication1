using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository;

namespace WebApplication1.ServiceLayer.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryBase<Employee> _repository;

        public EmployeeService(IRepositoryBase<Employee> repository)
        {
            _repository = repository;
        }

        public void DeleteEmployee(Employee employee)
        {
            _repository.Delete(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return _repository.Get(id);
        }

        public void InsertEmployee(Employee employee)
        {
            _repository.Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
