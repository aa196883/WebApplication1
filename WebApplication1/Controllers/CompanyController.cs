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
    public class CompanyController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IContext _context;

        public CompanyController(ILogger<EmployeeController> logger, IContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Company>? Get()
        {
            IEnumerable<Company> Companies = _context.Companies!;
            return Companies;
        }

        [HttpGet("{name}")]
        public async Task<Company> GetByName(string name)
        {
            IEnumerable<Company> companies = _context.Companies!.Include(list => list.Employees).AsNoTracking().Where(c => c.Name == name);
            if (companies.Any())
            {
                return companies.First();
            }
            throw new Exception("no company with name = " + name);
        }

        [HttpPost]
        public async Task<int> Post(Company company)
        {
            _context.Companies!.Add(company);
            await _context.SaveChangesAsync();
            return 0;
        }

        [HttpDelete("{name}")]
        async public Task<int> Delete(string name)
        {
            Company company = await GetByName(name);
            _context.Companies!.Remove(company);
            await _context.SaveChangesAsync();
            return 0;
        }

        [HttpPut("{name}")]
        async public Task<int> Put(string name, Company newCompany)
        {
            Company oldCompany = await GetByName(name);
            newCompany.Id = oldCompany.Id;
            _context.Companies!.Update(newCompany);
            await _context.SaveChangesAsync();
            return 0;
        }

        [HttpPatch("{name}")]
        async public Task<int> Patch(string name, Company newCompanyInfos)
        {
            Company companyToPatch = await GetByName(name);
            if (newCompanyInfos.NumberOfEmployees == 0)
            {
                newCompanyInfos.NumberOfEmployees = companyToPatch.NumberOfEmployees;
            }
            if (newCompanyInfos.Name == null || newCompanyInfos.Name == "")
            {
                newCompanyInfos.Name = companyToPatch.Name;
            }
            newCompanyInfos.Id = companyToPatch.Id;
            _context.Companies!.Update(newCompanyInfos);
            await _context.SaveChangesAsync();
            return 0;
        }
    }
}
