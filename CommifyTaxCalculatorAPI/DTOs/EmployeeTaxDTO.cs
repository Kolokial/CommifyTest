namespace CommifyTaxCalculatorAPI.DTOs;

public class EmployeeTaxDTO
{
    public int EmployeeId { get; set; }
    public decimal GrossAnnualSalary { get; set; }
    public decimal GrossMonthlySalary { get; set; }
    public decimal NetAnnualSalary { get; set; }
    public decimal NetMonthlySalary { get; set; }
    public decimal AnnualTaxPaid { get; set; }
    public decimal MonthlyTaxPaid { get; set; }
}
