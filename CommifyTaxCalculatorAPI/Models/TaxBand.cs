namespace CommifyTaxCalculatorAPI.Models;

public class TaxBand
{
    public int TaxBandId { get; set; }
    public string TaxBandName { get; set; }
    public int TaxBandRangeStart { get; set; }
    public int TaxBandRangeEnd { get; set; }
    public decimal TaxBandRate { get; set; }
}
