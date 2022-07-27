using WebApplication1.DomainLayer;
using Xunit;

namespace WebApplication1.UnitTests
{
    public class CompanyTests
    {
        [Fact]
        public void IsValid_CompanyIsValid_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            Company company = new();
            company.Name = "test";

            // Act
            bool actual = company.IsValid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValid_CompanyNameIsNull_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            Company company = new();
            company.Name = null;

            // Act
            bool actual = company.IsValid();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
