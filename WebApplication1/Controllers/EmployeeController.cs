using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetEmployee")]
        
        public IEnumerable<Employee> Get()
        {
            Context context = new Context();

            var employee = context.Employees!;

            return employee;
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            Context context = new Context();

            var employee = context.Employees!.Where(e => e.Id == id).First();
            context.Employees!.Add(employee);
            context.SaveChanges();

            return employee;
        }
    }
}

