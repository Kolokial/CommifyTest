using System.Text.Json;
using CommifyTaxCalculatorAPI.Services;
using Microsoft.EntityFrameworkCore;

public class EmployeeServiceTests
{
    private EmployeeService _service;
    private MockTaxCalculatorDatabaseContext _mockDb;

    public EmployeeServiceTests()
    {
        var options = new DbContextOptionsBuilder<MockTaxCalculatorDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "TestRegistrationDb" + DateTime.Now.Ticks)
            .Options;

        _mockDb = new MockTaxCalculatorDatabaseContext(options);
        _mockDb.Database.EnsureCreated();
        _service = new EmployeeService(_mockDb);
    }

    [Fact]
    public async Task GetEmployeeTaxRate_SendInvalidEmployeeId_ShouldThrow()
    {
        // Arrange

        // Act &  Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _service.GetEmployeeTaxBill(-1, CancellationToken.None)
        );
        Assert.Equal("Employee Id '-1' does not exist!", exception.Message);
    }

    [Fact]
    public async Task GetEmployeeTaxRate_SendCorrectEmployeeId_ReceiveCorrectCalculation()
    {
        // Arrange
        var employees = DataSeedHelpers.GetEmployees();
        var employeesTaxes = DataSeedHelpers.GetEmployeesTaxDTO();
        Random r = new Random();
        var index = r.Next(1, employees.Count);
        var employee = employees[index];
        var employeeTaxBill = employeesTaxes[index];

        // Act
        var result = await _service.GetEmployeeTaxBill(employee.EmployeeId, CancellationToken.None);
        Console.WriteLine(JsonSerializer.Serialize(result));
        Console.WriteLine(JsonSerializer.Serialize(employeeTaxBill));
        // Assert
        Assert.IsType<EmployeeTaxDTO>(result);
        Assert.Equivalent(result, employeeTaxBill);
    }

    [Fact]
    public async Task UpdateEmployeeSalary_SendInvalidEmployeeId_Throws()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _service.UpdateEmployeeSalary(-1, 1000, CancellationToken.None)
        );
        Assert.Equal("Employee Id '-1' does not exist!", exception.Message);
    }

    [Fact]
    public async Task UpdateEmployeeSalary_SendNegativeSalary_Throws()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(async () =>
            await _service.UpdateEmployeeSalary(1, -1000, CancellationToken.None)
        );
        Assert.Equal("Salary cannot be negative number. -1000", exception.Message);
    }

    [Fact]
    public async Task UpdateEmployeeSalary_SendCorrectIdAndPositiveSalary_EmployeeUpdated()
    {
        // Arrange
        var employees = DataSeedHelpers.GetEmployees();
        Random r = new Random();
        var index = r.Next(1, employees.Count);
        var employee = employees[index];

        // Act
        await _service.UpdateEmployeeSalary(
            employee.EmployeeId,
            employee.EmployeeAnnualSalary - 1000,
            CancellationToken.None
        );

        var dbEmployee = _mockDb.Employee.Single(x => x.EmployeeId == employee.EmployeeId);
        Assert.Equal(dbEmployee.EmployeeAnnualSalary, employee.EmployeeAnnualSalary - 1000);
    }
}
