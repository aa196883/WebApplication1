using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DomainLayer
{

    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
    }
}
