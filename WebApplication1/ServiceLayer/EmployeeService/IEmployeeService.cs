using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.EmployeeService
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        Employee DeleteEmployee(int id);
        Employee UpdateEmployee(int id, Employee employee);
        Employee InsertEmployee(Employee employee);
        Employee PatchEmployee(int id, Employee employee);

    }
}
