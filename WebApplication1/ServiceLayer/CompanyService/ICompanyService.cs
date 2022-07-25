using WebApplication1.DomainLayer;

namespace WebApplication1.ServiceLayer.CompanyService
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompany();
        Company GetCompany(string name);
        Company DeleteCompany(string Name);
        Company UpdateCompany(string Name, Company company);
        void InsertCompany(Company company);
        Company PatchCompany(string name, Company company);
    }
}
