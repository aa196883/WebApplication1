using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DomainLayer;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var res = _mediator.Send(new GetEmployeesQuerry()).Result;
            if (res == null)
            {
                return BadRequest("database is empty");
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var res = _mediator.Send(new GetEmployeeByIdQuerry(id)).Result;
            if (res == null)
            {
                return BadRequest("no employee found with id =" + id);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var res = _mediator.Send(new AddEmployeeCommand(employee)).Result;
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = _mediator.Send(new DeleteEmployeeCommand(id)).Result;
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Employee employee, int id)
        {
            var res = _mediator.Send(new UpdateEmployeeCommand(employee, id)).Result;
            return Ok(res);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Employee employee){
            var res = _mediator.Send(new PatchEmployeeCommand(employee, id)).Result;
            return Ok(res); ;
        }

    }
}

