using Api.Dtos.Comment;

namespace Api.Dtos.Stock;

public class StockDto
{
    public int Id { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchace { get; set; }

    public decimal Lastdiv { get; set; }

    public string Industry { get; set; } = string.Empty;

    public long Marketcap { get; set; }

    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
}
