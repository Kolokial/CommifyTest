namespace CommifyTaxCalculatorAPI.Requests;

public class UpdateEmployeeSalaryRequest
{
    public int EmployeeId { get; set; }
    public decimal NewSalary { get; set; }
}
