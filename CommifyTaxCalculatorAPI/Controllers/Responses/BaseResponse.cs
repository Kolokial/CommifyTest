namespace CommifyTaxCalculatorAPI.Responses;

public class BaseResponse
{
    public bool IsSuccess { get; set; }
    public List<ErrorResponse> Errors { get; set; }
}
