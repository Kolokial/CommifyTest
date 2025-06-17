using CommifyTaxCalculatorAPI.Requests;
using FluentValidation;

public class UpdateEmployeeSalaryRequestValidator : AbstractValidator<UpdateEmployeeSalaryRequest>
{
    public UpdateEmployeeSalaryRequestValidator()
    {
        RuleFor(o => o.EmployeeId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);

        RuleFor(o => o.NewSalary).NotNull().NotEmpty().GreaterThan(0);
    }
}
