using System.Collections.Immutable;
using System.Text.Json;
using System.Threading.Tasks;
using CommifyTaxCalculatorAPI.Data;
using CommifyTaxCalculatorAPI.DTOs;
using CommifyTaxCalculatorAPI.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CommifyTaxCalculatorAPI.Services;

public class EmployeeService
{
    private readonly ITaxCalculatorDatabaseContext _dbContext;

    public EmployeeService(ITaxCalculatorDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<EmployeeDTO>> GetEmployees(CancellationToken cancellationToken)
    {
        return (await _dbContext.Employee.ToListAsync(cancellationToken)).Select(x => x.Adapt<EmployeeDTO>());
    }

    public async Task<EmployeeTaxDTO> GetEmployeeTaxBill(int employeeId, CancellationToken ct)
    {
        var employee = await GetEmployee(employeeId);
        var taxBands = await _dbContext.TaxBand.ToListAsync(ct);

        var employeeTaxBands = taxBands.Where(x => employee.EmployeeAnnualSalary >= x.TaxBandRangeStart).ToList();
        var annualTaxAmount = GetNetSalary(employee.EmployeeAnnualSalary, employeeTaxBands);
        var netAnnualSalary = employee.EmployeeAnnualSalary - annualTaxAmount;
        return new EmployeeTaxDTO()
        {
            EmployeeId = employee.EmployeeId,
            GrossAnnualSalary = employee.EmployeeAnnualSalary,
            GrossMonthlySalary = Math.Round(employee.EmployeeAnnualSalary / 12, 2),
            NetMonthlySalary = Math.Round(netAnnualSalary / 12, 2),
            NetAnnualSalary = netAnnualSalary,
            AnnualTaxPaid = annualTaxAmount,
            MonthlyTaxPaid = Math.Round(annualTaxAmount / 12, 2),
        };
    }

    private async Task<Employee> GetEmployee(int employeeId)
    {
        var employee = await _dbContext.Employee.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (employee == null)
        {
            throw new ArgumentException($"Employee Id '{employeeId}' does not exist!");
        }
        return employee;
    }

    private decimal GetNetSalary(decimal salary, List<TaxBand> taxBands)
    {
        taxBands.Sort((tb1, tb2) => tb2.TaxBandRangeStart.CompareTo(tb2.TaxBandRangeStart));
        decimal taxBill = 0;

        foreach (var taxBand in taxBands)
        {
            var bandRangeEnd = taxBand.TaxBandRangeEnd;
            var bandRangeStart = taxBand.TaxBandRangeStart;
            if (salary >= bandRangeEnd)
            {
                taxBill += (bandRangeEnd - bandRangeStart) * taxBand.TaxBandRate;
                Console.WriteLine($"Salary > tax band {taxBand.TaxBandName}, current Tax bill {taxBill}");
            }
            else
            {
                taxBill += (salary - bandRangeStart) * taxBand.TaxBandRate;
                Console.WriteLine($"Salary < tax band {taxBand.TaxBandName}, current Tax bill {taxBill}");
            }
        }
        return taxBill;
    }

    public async Task UpdateEmployeeSalary(int employeeId, decimal newSalary, CancellationToken ct)
    {
        var employee = await GetEmployee(employeeId);

        if (newSalary < 0)
        {
            throw new Exception($"Salary cannot be negative number. {newSalary}");
        }
        employee.EmployeeAnnualSalary = newSalary;
        await _dbContext.SaveChangesAsync(ct);
    }
}
