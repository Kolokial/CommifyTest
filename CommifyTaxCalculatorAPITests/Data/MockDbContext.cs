using CommifyTaxCalculatorAPI.Data;
using CommifyTaxCalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;

public class MockTaxCalculatorDatabaseContext : DbContext, ITaxCalculatorDatabaseContext
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<TaxBand> TaxBand { get; set; }

    public MockTaxCalculatorDatabaseContext(
        DbContextOptions<MockTaxCalculatorDatabaseContext> options
    )
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxBand>().HasData(DataSeedHelpers.GetTaxBands());
        modelBuilder.Entity<Employee>().HasData(DataSeedHelpers.GetEmployees());
    }
}
