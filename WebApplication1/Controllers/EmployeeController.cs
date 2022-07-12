using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            _logger.LogInformation("information");
            IEnumerable<Employee> data = Enumerable.Range(1, 10).Select(index => new Employee
            {
                Id = Random.Shared.Next(0, 100),
                Name = "a"
            })
            .ToArray();

            return data;
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            return new Employee
            {
                Id = id,
                Name = ((char) id).ToString()
            };
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

