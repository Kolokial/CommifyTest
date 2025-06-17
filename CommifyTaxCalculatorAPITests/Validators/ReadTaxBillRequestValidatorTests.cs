using FluentValidation.TestHelper;

public class ReadTaxBillRequestValidatorTests
{
    private ReadTaxBillRequestValidator validator;

    public ReadTaxBillRequestValidatorTests()
        : base()
    {
        validator = new ReadTaxBillRequestValidator();
    }

    [Fact]
    public void Should_error_when_EmployeeId_is_empty()
    {
        var model = new ReadTaxBillRequest() { };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.EmployeeId);
    }

    [Fact]
    public void Should_error_when_EmployeeId_is_less_than_zero()
    {
        var model = new ReadTaxBillRequest() { EmployeeId = -1 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.EmployeeId);
    }
}
