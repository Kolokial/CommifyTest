using CommifyTaxCalculatorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommifyTaxCalculatorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public ObjectResult GetEmployees(CancellationToken cancellationToken)
    {
        return Ok(_employeeService.GetEmployees(cancellationToken));
    }
}
