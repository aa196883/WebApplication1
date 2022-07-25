using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.RepositoryLayer;

namespace WebApplication1.DomainLayer
{

    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }


        public Employee(int id, int employeeId, string name, int companyId)
        {
            Id = id;
            EmployeeId = employeeId;
            Name = name;
            CompanyId = companyId;
        }

        public Employee(IContext context, EmployeeInfos employeeInfos)
        {
            EmployeeId = employeeInfos.EmployeeId;
            Name = employeeInfos.Name;

            IQueryable<Company> querry = context.Companies!.AsNoTracking().Where(c => c.Name == employeeInfos.CompanyName);
            if (!querry.Any())
            {
                throw new Exception("ERROR: some employee Infos are not valid");
            }
            CompanyId = querry.First().Id;
        }
    }
}
