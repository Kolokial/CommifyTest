using CommifyTaxCalculatorAPI.DTOs;

namespace CommifyTaxCalculatorAPI.Responses;

public class EmployeeTaxResponse : BaseResponse, ISuccessfulResult<EmployeeTaxDTO>
{
    public EmployeeTaxDTO Result { get; set; }
}
