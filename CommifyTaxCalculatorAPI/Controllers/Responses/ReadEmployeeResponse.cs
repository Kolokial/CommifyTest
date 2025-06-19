using CommifyTaxCalculatorAPI.DTOs;
using CommifyTaxCalculatorAPI.Responses;

public class ReadEmployeeResponse : BaseResponse, ISuccessfulResult<EmployeeDTO>
{
    public EmployeeDTO Result { get; set; }
}
