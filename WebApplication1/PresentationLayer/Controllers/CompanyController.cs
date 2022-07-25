using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DomainLayer;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var res = _mediator.Send(new GetCompaniesQuerry()).Result;
            if (res == null)
            {
                return BadRequest("database is empty");
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public IActionResult GetCompany(string name)
        {
            try
            {
                var res = _mediator.Send(new GetCompanyByNameQuerry(name)).Result;
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Company company)
        {
            var res = _mediator.Send(new AddCompanyCommand(company)).Result;
            return Ok(res);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var res = _mediator.Send(new DeleteCompanyCommand(name)).Result;
            return Ok(res);
        }

        [HttpPut("{name}")]
        public IActionResult Put(Company company, string name)
        {
            var res = _mediator.Send(new UpdateCompanyCommand(company, name)).Result;
            return Ok(res);
        }

        [HttpPatch("{name}")]
        public IActionResult Patch(string name, Company company)
        {
            var res = _mediator.Send(new PatchCompanyCommand(company, name)).Result;
            return Ok(res); ;
        }

    }
}

