using MediatR;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
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
        private readonly IMediator _mediatr = Substitute.For<IMediator>();


        [Fact]
        public void GetAll_ValidCall_ReturnsAll()
        {
            // Arrange
            Company[] array = { new Company { Name="test1" }, new Company { Name = "test2" } };
            _repository.GetAll().Returns(array.AsEnumerable());
            GetCompaniesHandler handler = new(_repository);
            // Act
            var res = handler.Handle(new GetCompaniesQuery(), default).Result;
            // Assert
            Assert.Equal(array.Length, res.Count());
            for(int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i].Name, res.ElementAt(i).Name);
            }
        }

        [Theory]
        [InlineData("not_valid")]
        public void GetByName_InvalidName_ReturnsNull(string name)
        {
            // Arrange
            _repository.GetByName(name).ReturnsNull();
            GetCompanyByNameHandler handler = new(_repository);

            // Act
            var res = handler.Handle(new GetCompanyByNameQuery(name), default).Result;

            // Assert
            Assert.Null(res);
        }

        [Theory]
        [InlineData("valid")]
        public void GetByName_ValidName_ReturnsComapny(string name)
        {
            // Arrange
            Company expected = new() { Name = name };
            _repository.GetByName(name).Returns(expected);
            GetCompanyByNameHandler handler = new(_repository);

            // Act
            Company? actual = handler.Handle(new GetCompanyByNameQuery(name), default).Result;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("invalid")]
        public void Delete_InvalidName_ReturnsNull(string name)
        {
            // Arrange
            DeleteCompanyHandler handler = new(_repository, _mediatr);
            GetCompanyByNameQuery command = new(name);
            _mediatr.Send(command).ReturnsNull();

            // Act
            Company actual = handler.Handle(new DeleteCompanyCommand(name), default).Result;

            // Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("valid")]
        public void Delete_ValidName_ReturnsDeletedCompany(string name)
        {
            // Arrange
            Company expected = new() { Name = name };
            DeleteCompanyHandler handler = new(_repository, _mediatr);
            GetCompanyByNameQuery command = new(name);
            _mediatr.Send(command).Returns(Task.FromResult(expected));

            // Act
            Company actual = handler.Handle(new DeleteCompanyCommand(name), default).Result;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
