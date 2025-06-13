using Microsoft.AspNetCore.Mvc;
using CommifyTaxCalculatorAPI.DTOs;
using CommifyTaxCalculatorAPI.Services;

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

    [HttpGet(Name = "Employees")]
    public IEnumerable<EmployeeDTO> Get()
    {
        return _employeeService.GetEmployees();
    }
}