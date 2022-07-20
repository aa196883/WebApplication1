using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    
    public class Employee { 
        
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
    }
}
