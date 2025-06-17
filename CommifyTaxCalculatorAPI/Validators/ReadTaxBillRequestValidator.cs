using FluentValidation;

public class ReadTaxBillRequestValidator : AbstractValidator<ReadTaxBillRequest>
{
    public ReadTaxBillRequestValidator()
    {
        RuleFor(p => p.EmployeeId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
    }
}
