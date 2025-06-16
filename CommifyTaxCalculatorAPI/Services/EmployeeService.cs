using System.Threading.Tasks;
using CommifyTaxCalculatorAPI.DTOs;
using CommifyTaxCalculatorAPI.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace CommifyTaxCalculatorAPI.Services;

public class EmployeeService
{
    private readonly TaxCalculatorDatabaseContext _dbContext;
    public EmployeeService(TaxCalculatorDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<EmployeeDTO> GetEmployees(CancellationToken cancellationToken)
    {
        return (await _dbContext.Employee.ToListAsync(cancellationToken)).Adapt<EmployeeDTO>();
    }

    public async Task<EmployeeTaxDTO> GetEmployeeTaxRate(int employeeId, CancellationToken ct)
    {
        var employee = _dbContext.Employee.FirstOrDefault(x => x.EmployeeId == employeeId);

        if (employee == null)
        {
            throw new ArgumentException("Employee Id does not exist!");
        }

        var taxRate = await _dbContext.TaxBand.ToListAsync(ct);
        taxRate.Sort();


    }
}