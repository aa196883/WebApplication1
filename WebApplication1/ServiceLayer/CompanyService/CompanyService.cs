using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;

namespace WebApplication1.ServiceLayer.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository<Company> _repository;

        public CompanyService(ICompanyRepository<Company> repository)
        {
            _repository = repository;
        }

        public Company DeleteCompany(string Name)
        {
            Company company = this.GetCompany(Name);
            _repository.Delete(company);
            return company;
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _repository.GetAll();
        }

        public Company GetCompany(string name)
        {
            return _repository.GetByName(name);
        }

        public void InsertCompany(Company company)
        {
            _repository.Insert(company);
        }

        public Company PatchCompany(string Name, Company newCompany)
        {
            Company oldCompany = this.GetCompany(Name);
            if (newCompany.NumberOfEmployees == 0)
            {
                newCompany.NumberOfEmployees = oldCompany.NumberOfEmployees;
            }
            if (newCompany.Name == null || oldCompany.Name == "")
            {
                newCompany.Name = oldCompany.Name;
            }
            newCompany.Id = oldCompany.Id;
            _repository.Update(newCompany);
            return newCompany;
        }

        public Company UpdateCompany(string Name, Company company)
        {
            int id = this.GetCompany(Name).Id;
            company.Id = id;
            _repository.Update(company);
            return company;
        }
    }
}
