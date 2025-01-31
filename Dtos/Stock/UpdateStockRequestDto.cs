namespace Api.Dtos.Stock;

public class UpdateStockRequestDto
{
    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchace { get; set; }

    public decimal Lastdiv { get; set; }

    public string Industry { get; set; } = string.Empty;

    public long Marketcap { get; set; }
}