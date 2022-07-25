using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DomainLayer;
using WebApplication1.ServiceLayer.CompanyService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var res = _companyService.GetAllCompany();
            if(res == null)
            {
                return BadRequest("database is empty");
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public IActionResult GetCompanyByName(string name)
        {
            var res = _companyService.GetCompany(name);
            if (res == null)
            {
                return BadRequest("no employee found with name = " + name);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(Company company)
        {
            _companyService.InsertCompany(company);
            return Ok(company);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            Company company = _companyService.DeleteCompany(name);
            return Ok(company);
        }

        [HttpPut("{name}")]
        public IActionResult Put(Company company, string name)
        {
            Company newCompany = _companyService.UpdateCompany(name, company);
            return Ok(newCompany);
        }

        [HttpPatch("{name}")]
        public IActionResult Patch(Company company, string name)
        {
            Company patchedCompany = _companyService.PatchCompany(name, company);
            return Ok(patchedCompany);
        }
    }
}

