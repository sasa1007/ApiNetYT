using Api.Dtos.Stock;
using Api.Helpers;
using Api.Models;

namespace Api.Repository;

public interface IStockRepository
{
    Task<List<Stock>> GetAllSync(QuerryObject querryObject);

    Task<Stock?> GetByIdAsync(int id);

    Task<Stock> CreateAsync(Stock stockModel);

    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

    Task<Stock?> DeleteAsync(int id);

    Task <bool> StockExists(int id);
}