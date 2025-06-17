using CommifyTaxCalculatorAPI.Requests;
using CommifyTaxCalculatorAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CommifyTaxCalculatorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private EmployeeService _employeeService;
    private IValidator<UpdateEmployeeSalaryRequest> _salaryRequestValidator;
    private IValidator<ReadTaxBillRequest> _taxBillRequestValidator;

    public EmployeesController(
        EmployeeService employeeService,
        IValidator<UpdateEmployeeSalaryRequest> salaryValidator,
        IValidator<ReadTaxBillRequest> taxBillRequestValidator
    )
    {
        _employeeService = employeeService;
        _salaryRequestValidator = salaryValidator;
        _taxBillRequestValidator = taxBillRequestValidator;
    }

    [HttpGet]
    public ObjectResult GetEmployees(CancellationToken cancellationToken)
    {
        return Ok(_employeeService.GetEmployees(cancellationToken));
    }

    [HttpPatch, Route("UpdateSalary")]
    public ObjectResult UpdateEmployeeSalary(
        [FromBody] UpdateEmployeeSalaryRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = _salaryRequestValidator.Validate(request);
        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }
        return Ok(_employeeService.UpdateEmployeeSalary(request.EmployeeId, request.NewSalary, cancellationToken));
    }

    [HttpGet, Route("ReadTaxBill")]
    public ObjectResult GetTaxBil(int id, CancellationToken ct)
    {
        var results = _taxBillRequestValidator.Validate(new ReadTaxBillRequest { EmployeeId = id });
        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }
        return Ok(_employeeService.GetEmployeeTaxBill(id, ct));
    }
}
