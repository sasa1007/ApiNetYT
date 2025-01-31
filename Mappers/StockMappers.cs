using Api.Dtos.Stock;
using Api.Models;

namespace Api.Mappers;

public static class StockMappers
{

    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchace = stockModel.Purchace,
            Lastdiv = stockModel.Lastdiv,
            Marketcap = stockModel.Marketcap,
            Industry = stockModel.Industry,
        };
    }

    public static Stock ToStockFromCreatedDto(this CreateStockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchace = stockDto.Purchace,
            Lastdiv = stockDto.Lastdiv,
            Marketcap = stockDto.Marketcap,
            Industry = stockDto.Industry,
        };
    }

}