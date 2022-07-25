using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.EmployeeService
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void InsertEmployee(Employee employee);

    }
}
