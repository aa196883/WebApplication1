using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer;
using WebApplication1.ServiceLayer.CompanyService;
using WebApplication1.ServiceLayer.EmployeeService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var res = _employeeService.GetAllEmployee();
            if (res == null)
            {
                return BadRequest("database is empty");
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var res = _employeeService.GetEmployee(id);
            if (res == null)
            {
                return BadRequest("no employee found with id =" + id);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _employeeService.InsertEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeService.DeleteEmployee(id);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Employee employee, int id)
        {
            _employeeService.UpdateEmployee(id, employee);
            return Ok(employee);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Employee employee){
            _employeeService.PatchEmployee(id, employee);
            return Ok(employee);
        }

}
}

