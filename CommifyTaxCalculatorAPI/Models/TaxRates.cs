namespace CommifyTaxCalculatorAPI.Models;

public class TaxBand
{
    public int TaxBandId { get; set; }
    public string TaxBandName { get; set; }
    public decimal TaxBandRangeStart { get; set; }
    public decimal TaxBandRangeEnd { get; set; }
    public double TaxBandRate { get; set; }
}