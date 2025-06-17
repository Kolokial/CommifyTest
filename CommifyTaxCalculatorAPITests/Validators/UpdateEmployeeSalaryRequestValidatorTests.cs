using CommifyTaxCalculatorAPI.Requests;
using FluentValidation.TestHelper;

public class UpdateEmployeeSalaryRequestValidatorTests
{
    private UpdateEmployeeSalaryRequestValidator validator;

    public UpdateEmployeeSalaryRequestValidatorTests()
        : base()
    {
        validator = new UpdateEmployeeSalaryRequestValidator();
    }

    [Fact]
    public void Should_error_when_EmployeeId_is_empty()
    {
        var model = new UpdateEmployeeSalaryRequest() { NewSalary = 99 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.EmployeeId);
    }

    [Fact]
    public void Should_error_when_EmployeeId_is_less_than_zero()
    {
        var model = new UpdateEmployeeSalaryRequest() { NewSalary = 99, EmployeeId = -1 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.EmployeeId);
    }

    [Fact]
    public void Should_error_when_NewSalary_is_empty()
    {
        var model = new UpdateEmployeeSalaryRequest() { EmployeeId = 1 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.NewSalary);
    }

    [Fact]
    public void Should_error_when_NewSalary_is_less_than_zero()
    {
        var model = new UpdateEmployeeSalaryRequest() { NewSalary = -1, EmployeeId = 1 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(req => req.NewSalary);
    }
}
