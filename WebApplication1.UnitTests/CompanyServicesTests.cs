using Microsoft.EntityFrameworkCore;
using NSubstitute;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer;
using WebApplication1.RepositoryLayer.Repository.RepoBase;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.ServiceLayer.Handlers.CompanyHandlers;
using WebApplication1.ServiceLayer.Queries.CompanyQueries;
using Xunit;

namespace WebApplication1.UnitTests
{
    public class CompanyServicesTests
    {
        private readonly ICompanyRepository<Company> _repository = Substitute.For<ICompanyRepository<Company>>();


        [Fact]
        public void GetAll_ValidCall_ReturnsAll()
        {
            // Arrange
            Company[] array = { new Company { Name="test1" }, new Company { Name = "test2" } };
            _repository.GetAll().Returns(array.AsEnumerable());
            GetCompaniesHandler handler = new GetCompaniesHandler(_repository);
            // Act
            var res = handler.Handle(new GetCompaniesQuerry(), default).Result;
            // Assert
            Assert.Equal(array.Length, res.Count());
            for(int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i].Name, res.ElementAt(i).Name);
            }
        }

        [Theory]
        [InlineData()]
        public void Get_InValidName_ReturnsNull()
        {
            // Arrange

        }
    }
}
