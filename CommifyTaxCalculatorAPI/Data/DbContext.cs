using CommifyTaxCalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;
public class TaxCalculatorDatabaseContext : DbContext
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<TaxBand> TaxBand { get; set; }

    public TaxCalculatorDatabaseContext(DbContextOptions<TaxCalculatorDatabaseContext> options)
            : base(options)
    { }

}