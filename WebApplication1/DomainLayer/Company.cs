using WebApplication1.DomainLayer;

namespace WebApplication1.DomainLayer
{
    public class Company : BaseEntity
    {
        public int NumberOfEmployees { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
