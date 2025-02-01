using Api.Dtos.Stock;
using Api.Models;

namespace Api.Repository;

public interface IStockrepository
{
    Task<List<Stock>> GetAllSync();

    Task<Stock?> GetByIdAsync(int id);

    Task<Stock> CreateAsync(Stock stockModel);

    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

    Task<Stock?> DeleteAsync(int id);
}