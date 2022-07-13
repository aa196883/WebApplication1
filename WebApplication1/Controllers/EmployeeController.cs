using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

            return employee;
        }

        [HttpPost]
        public Employee Post(Employee employee)
        {
            string fullPath = @"C:\repo\testWrite.json";
            
            System.IO.File.AppendAllText(fullPath, JsonConvert.SerializeObject(employee));
            return employee;
        }
    }
}

