using Api.Data;
using Api.Dtos.Stock;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class StockRepository : IStockRepository
{
    private readonly AplicationDbContext _context;

    public StockRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Stock>> GetAllSync()
    {
        return await _context.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks.FindAsync(id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
    {
        var existingStock= await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (existingStock == null)
        {
            return null;
        }

        existingStock.Symbol = updateStockRequestDto.Symbol;
        existingStock.CompanyName = updateStockRequestDto.CompanyName;
        existingStock.Marketcap = updateStockRequestDto.Marketcap;
        existingStock.Purchace = updateStockRequestDto.Purchace;
        existingStock.Industry = updateStockRequestDto.Industry;
        existingStock.Lastdiv = updateStockRequestDto.Lastdiv;

        await _context.SaveChangesAsync();

        return existingStock;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null)
        {
            return null;
        }

        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }
}