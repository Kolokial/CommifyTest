using CommifyTaxCalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommifyTaxCalculatorAPI.Data;

public class TaxCalculatorDatabaseContext : DbContext, ITaxCalculatorDatabaseContext
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<TaxBand> TaxBand { get; set; }

    public TaxCalculatorDatabaseContext(DbContextOptions<TaxCalculatorDatabaseContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TaxBand>(b =>
            b.HasData(
                new TaxBand
                {
                    TaxBandId = 1,
                    TaxBandName = "Tax Band A",
                    TaxBandRangeStart = 0,
                    TaxBandRangeEnd = 5000,
                    TaxBandRate = 0,
                },
                new TaxBand
                {
                    TaxBandId = 2,
                    TaxBandName = "Tax Band B",
                    TaxBandRangeStart = 5000,
                    TaxBandRangeEnd = 20000,
                    TaxBandRate = 0.2M,
                },
                new TaxBand
                {
                    TaxBandId = 3,
                    TaxBandName = "Tax Band C",
                    TaxBandRangeStart = 20000,
                    TaxBandRangeEnd = int.MaxValue,
                    TaxBandRate = 0.4M,
                }
            )
        );

        modelBuilder.Entity<Employee>(b =>
            b.HasData(
            new Employee
            {
                EmployeeId = 1,
                EmployeeFirstName = "Marge",
                EmployeeLastName = "Simpson",
                EmployeeAnnualSalary = 15000,
            },
            new Employee
            {
                EmployeeId = 2,
                EmployeeFirstName = "Homer",
                EmployeeLastName = "Simpson",
                EmployeeAnnualSalary = 40000,
            },
            new Employee
            {
                EmployeeId = 3,
                EmployeeFirstName = "Seymour",
                EmployeeLastName = "Skinner",
                EmployeeAnnualSalary = 35000,
            },
            new Employee
            {
                EmployeeId = 4,
                EmployeeFirstName = "Montgomery",
                EmployeeLastName = "Burns",
                EmployeeAnnualSalary = 66000,
            },
            new Employee
            {
                EmployeeId = 5,
                EmployeeFirstName = "Waylon",
                EmployeeLastName = "Smithers",
                EmployeeAnnualSalary = 58000,
            },
            new Employee
            {
                EmployeeId = 6,
                EmployeeFirstName = "Lisa",
                EmployeeLastName = "Simpson",
                EmployeeAnnualSalary = 95000, // She's a genius
            },
            new Employee
            {
                EmployeeId = 7,
                EmployeeFirstName = "Carl",
                EmployeeLastName = "Carlson",
                EmployeeAnnualSalary = 47000,
            },
            new Employee
            {
                EmployeeId = 8,
                EmployeeFirstName = "Lenny",
                EmployeeLastName = "Leonard",
                EmployeeAnnualSalary = 46000,
            },
            new Employee
            {
                EmployeeId = 9,
                EmployeeFirstName = "Barney",
                EmployeeLastName = "Gumble",
                EmployeeAnnualSalary = 39000,
            })
        );
    }
}
