using Api.Dtos.Stock;
using Api.Models;

namespace Api.Mappers;

public static class StockMappers
{

    public static StockDto ToStockDto(this Stock stock)
    {
        return new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchace = stock.Purchace,
            Lastdiv = stock.Lastdiv,
            Marketcap = stock.Marketcap,
            Industry = stock.Industry,
            Comments = stock.Comments.Select(c=>c.ToCommentDto()).ToList(),
        };
    }

    public static Stock ToStockFromCreatedDto(this CreateStockRequestDto createStockRequestDto)
    {
        return new Stock
        {
            Symbol = createStockRequestDto.Symbol,
            CompanyName = createStockRequestDto.CompanyName,
            Purchace = createStockRequestDto.Purchace,
            Lastdiv = createStockRequestDto.Lastdiv,
            Marketcap = createStockRequestDto.Marketcap,
            Industry = createStockRequestDto.Industry,
        };
    }

}