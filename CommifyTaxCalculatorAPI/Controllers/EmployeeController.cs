using System.Threading.Tasks;
using CommifyTaxCalculatorAPI.Requests;
using CommifyTaxCalculatorAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CommifyTaxCalculatorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private EmployeeService _employeeService;
    private IValidator<UpdateEmployeeSalaryRequest> _salaryRequestValidator;
    private IValidator<ReadTaxBillRequest> _taxBillRequestValidator;
    private IValidator<ReadEmployeeRequest> _readEmployeeRequestValidator;

    public EmployeeController(
        EmployeeService employeeService,
        IValidator<UpdateEmployeeSalaryRequest> salaryValidator,
        IValidator<ReadTaxBillRequest> taxBillRequestValidator,
        IValidator<ReadEmployeeRequest> readEmployeeRequestValidator
    )
    {
        _employeeService = employeeService;
        _salaryRequestValidator = salaryValidator;
        _taxBillRequestValidator = taxBillRequestValidator;
        _readEmployeeRequestValidator = readEmployeeRequestValidator;
    }

    [HttpGet]
    public async Task<ObjectResult> GetEmployee(int id, CancellationToken cancellationToken)
    {
        var validationResults = _readEmployeeRequestValidator.Validate(new ReadEmployeeRequest { EmployeeId = id });
        if (!validationResults.IsValid)
        {
            return BadRequest(validationResults.Errors);
        }

        var response = await _employeeService.ReadEmployee(id, cancellationToken);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPatch, Route("UpdateSalary")]
    public async Task<ObjectResult> UpdateEmployeeSalary(
        [FromBody] UpdateEmployeeSalaryRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = _salaryRequestValidator.Validate(request);
        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }

        var response = await _employeeService.UpdateEmployeeSalary(
            request.EmployeeId,
            request.NewSalary,
            cancellationToken
        );

        if (!response.IsSuccess)
        {
            return BadRequest(response.Errors);
        }
        return Ok(response);
    }

    [HttpGet, Route("ReadTaxBill")]
    public async Task<ObjectResult> GetTaxBil(int id, CancellationToken ct)
    {
        var results = _taxBillRequestValidator.Validate(new ReadTaxBillRequest { EmployeeId = id });
        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }
        var response = await _employeeService.GetEmployeeTaxBill(id, ct);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}
