using CommifyTaxCalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommifyTaxCalculatorAPI.Data;

public interface ITaxCalculatorDatabaseContext
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<TaxBand> TaxBand { get; set; }
}
