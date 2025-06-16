using System.Text.Json;
using CommifyTaxCalculatorAPI.Controllers;
using CommifyTaxCalculatorAPI.DTOs;
using CommifyTaxCalculatorAPI.Models;
using CommifyTaxCalculatorAPI.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NJsonSchema.Yaml;

public class EmployeeServiceTests
{
    private EmployeeService _service;

    public EmployeeServiceTests()
        : base()
    {
        var options = new DbContextOptionsBuilder<MockTaxCalculatorDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "TestRegistrationDb" + DateTime.Now.Ticks)
            .Options;

        var mockDb = new MockTaxCalculatorDatabaseContext(options);
        mockDb.Database.EnsureCreated();
        _service = new EmployeeService(mockDb);
    }

    [Fact]
    public async Task GetEmployeeTaxRate_SendInvalidEmployeeId_ShouldThrow()
    {
        // Arrange

        // Act &  Assert
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _service.GetEmployeeTaxRate(-1, CancellationToken.None)
        );
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
        var result = await _service.GetEmployeeTaxRate(
            employee.EmployeeId,
            CancellationToken.None
        );
        Console.WriteLine(JsonSerializer.Serialize(result));
        Console.WriteLine(JsonSerializer.Serialize(employeeTaxBill));
        // Assert
        Assert.IsType<EmployeeTaxDTO>(result);
        Assert.Equivalent(result, employeeTaxBill);
    }
}
