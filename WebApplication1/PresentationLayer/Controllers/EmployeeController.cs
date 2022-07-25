using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer;
using WebApplication1.ServiceLayer.EmployeeService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _companyService;

        public EmployeeController(IEmployeeService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var res = _companyService.GetAllEmployee();
            if (res == null)
            {
                return BadRequest("database is empty");
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var res = _companyService.GetEmployee(id);
            if (res == null)
            {
                return BadRequest("no employee found with id =" + id);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(Employee company)
        {
            _companyService.InsertEmployee(company);
            return Ok(company);
        }

        [HttpDelete]
        public IActionResult Delete(Employee company)
        {
            _companyService.DeleteEmployee(company);
            return Ok(company);
        }

        [HttpPut]
        public IActionResult Put(Employee company)
        {
            _companyService.UpdateEmployee(company);
            return Ok(company);
        }

        //[HttpPatch("{id}")]
        //async public Task<IActionResult> Patch(int id, EmployeeInfos employeeInfos)
        //{
            
        //    Employee employeeToPatch = await GetById(id);

        //    if (employeeInfos.EmployeeId == 0)
        //    {
        //        employeeInfos.EmployeeId = employeeToPatch.EmployeeId;
        //    }
        //    if (employeeInfos.Name == null || employeeInfos.Name == "")
        //    {
        //        employeeInfos.Name = employeeToPatch.Name;
        //    }

        //    Employee newEmployee;
        //    if (employeeInfos.EmployeeName == null)
        //    {
        //        newEmployee = new(employeeToPatch.Id, employeeInfos.EmployeeId, employeeInfos.Name, employeeToPatch.EmployeeId);
        //    }
        //    else
        //    {
        //        newEmployee = new(_context, employeeInfos);
        //    }

            
        //    newEmployee.Id = employeeToPatch.Id;
        //    _context.Employees!.Update(newEmployee);
        //    await _context.SaveChangesAsync();
        //    return Ok(newEmployee);
        //}

    }
}

