using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet(Name = "GetEmployee")]
        
        public IEnumerable<Employee> Get()
        {
            var employee = _context.Employees!;
            return employee;
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            try
            {
                var employee = _context.Employees!.Where(e => e.EmployeeId == id).First();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void Post(Employee employee)
        {
            _context.Employees!.Add(employee);
            _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Employees!.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}

