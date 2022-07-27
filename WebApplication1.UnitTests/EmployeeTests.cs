using WebApplication1.DomainLayer;
using Xunit;

namespace WebApplication1.UnitTests
{
    public class EmployeeTests
    {
        [Fact]
        public void IsValid_EmployeeIsValid_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            Employee employee = new();
            employee.Name = "test";
            employee.EmployeeId = 1;
            employee.CompanyId = 1;

            // Act
            bool actual = employee.IsValid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, 1,1)]
        [InlineData("test", 0, 1)]
        [InlineData("test", 1, 0)]
        public void IsValid_EmployeeInfoInvalid_ReturnsFalse(string name, int employeeId, int companyId)
        {
            // Arrange
            bool expected = false;
            Employee employee = new();
            employee.Name = name;
            employee.EmployeeId = employeeId;
            employee.CompanyId = companyId;

            // Act
            bool actual = employee.IsValid();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}