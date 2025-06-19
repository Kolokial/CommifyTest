using CommifyTaxCalculatorAPI.DTOs;
using CommifyTaxCalculatorAPI.Responses;

public class EmployeesResponse : BaseResponse, ISuccessfulResult<IEnumerable<EmployeeDTO>>
{
    public IEnumerable<EmployeeDTO> Result { get; set; }
}
