using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IContext _context;

        public EmployeeController(ILogger<EmployeeController> logger, IContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Employee>? Get()
        {
            IEnumerable<Employee> employees = _context.Employees!;
            return employees;
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id)
        {
            IEnumerable<Employee> employees = _context.Employees!.AsNoTracking().Where(e => e.EmployeeId == id);
            if (employees.Any())
            {
                return employees.First();
            }
            throw new Exception("no employee with ID = "+ id);
        }

        [HttpPost]
        public async Task<int> Post(Employee employee)
        {
            _context.Employees!.Add(employee);
            await _context.SaveChangesAsync();
            return 0;
        }

        [HttpDelete("{id}")]
        async public Task<int> Delete(int id)
        {
            Employee employee = await GetById(id);
            _context.Employees!.Remove(employee);
            await _context.SaveChangesAsync();
            return 0;
        }

        [HttpPut("{id}")]
        async public Task<int> Put(int id, Employee newEmployee)
        {
            Employee oldEmployee = await GetById(id);
            newEmployee.Id = oldEmployee.Id;
            _context.Employees!.Update(newEmployee);
            await _context.SaveChangesAsync();
            return 0;
        }

        [HttpPatch("{id}")]
        async public Task<int> Patch(int id, Employee newEmployeeInfos)
        {
            Employee employeeToPatch = await GetById(id);
            if (newEmployeeInfos.EmployeeId == 0)
            {
                newEmployeeInfos.EmployeeId = employeeToPatch.EmployeeId;
            }
            if (newEmployeeInfos.Name == null || newEmployeeInfos.Name == "")
            {
                newEmployeeInfos.Name = employeeToPatch.Name;
            }
            newEmployeeInfos.Id = employeeToPatch.Id;
            _context.Employees!.Update(newEmployeeInfos);
            await _context.SaveChangesAsync();
            return 0;
        }

    }
}

