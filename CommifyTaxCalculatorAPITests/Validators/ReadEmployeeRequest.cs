using FluentValidation.TestHelper;

public class ReadEmployeeRequestValidatorTests
{
    private ReadEmployeeRequestValidator validator;

    public ReadEmployeeRequestValidatorTests()
    {
        validator = new ReadEmployeeRequestValidator();
    }

    [Fact]
    public void Should_error_when_EmployeeId_is_empty()
    {
        var model = new ReadEmployeeRequest() { };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.EmployeeId);
    }

    [Fact]
    public void Should_error_when_EmployeeId_is_less_than_zero()
    {
        var model = new ReadEmployeeRequest() { EmployeeId = -1 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.EmployeeId);
    }
}
