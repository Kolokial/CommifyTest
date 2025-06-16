using CommifyTaxCalculatorAPI.Models;

public static class DataSeedHelpers
{
    public static List<TaxBand> GetTaxBands()
    {
        return new List<TaxBand>
        {
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
            },
        };
    }

    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
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
        };
    }

    public static List<EmployeeTaxDTO> GetEmployeesTaxDTO()
    {
        return new List<EmployeeTaxDTO>
        {
            new EmployeeTaxDTO
            {
                EmployeeId = 1,
                AnnualTaxPaid = 2000,
                GrossAnnualSalary = 15000,
                GrossMonthlySalary = 1250,
                MonthlyTaxPaid = 166.67M,
                NetAnnualSalary = 13000,
                NetMonthlySalary = 1083.33M,
            },
            new EmployeeTaxDTO
            {
                EmployeeId = 2,
                AnnualTaxPaid = 11000.0M,
                GrossAnnualSalary = 40000,
                GrossMonthlySalary = 3333.33M,
                MonthlyTaxPaid = 916.67M,
                NetAnnualSalary = 29000.0M,
                NetMonthlySalary = 2416.67M,
            },
            new EmployeeTaxDTO
            {
                EmployeeId = 3,
                AnnualTaxPaid = 9000.0M,
                GrossAnnualSalary = 35000.0M,
                GrossMonthlySalary = 2916.67M,
                MonthlyTaxPaid = 750.0M,
                NetAnnualSalary = 29000.0M,
                NetMonthlySalary = 2166.67M,
            },
            new EmployeeTaxDTO
            {
                EmployeeId = 4,
                AnnualTaxPaid = 21400.0M,
                GrossAnnualSalary = 66000.0M,
                GrossMonthlySalary = 5500,
                MonthlyTaxPaid = 1783.33M,
                NetAnnualSalary = 44600.0M,
                NetMonthlySalary = 3716.67M,
            },
        };
    }
}
