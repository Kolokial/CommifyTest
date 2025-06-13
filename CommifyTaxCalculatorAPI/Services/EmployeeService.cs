using CommifyTaxCalculatorAPI.Models;


namespace CommifyTaxCalculatorAPI.Services;

public class EmployeeService
{
    private readonly TaxCalculatorDatabaseContext _dbContext;
    public EmployeeService(TaxCalculatorDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<IEnumerable<Employee>> GetEmployees()
    {
        return _dbContext.Employee;
    }
}