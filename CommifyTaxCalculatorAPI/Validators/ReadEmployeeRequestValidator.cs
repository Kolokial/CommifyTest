using FluentValidation;

public class ReadEmployeeRequestValidator : AbstractValidator<ReadEmployeeRequest>
{
    public ReadEmployeeRequestValidator()
    {
        RuleFor(p => p.EmployeeId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
    }
}
