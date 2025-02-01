using Api.Data;
using Api.Dtos.Stock;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("/api/stock")]
public class StockController : ControllerBase
{
    private readonly AplicationDbContext _context;

    public StockController(AplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var stocks = await _context.Stocks.ToListAsync();

        var StockDtop = stocks.Select(s => s.ToStockDto());

        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _context.Stocks.FindAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStockRequestDto stockDto)
    {
        var stockModel = stockDto.ToStockFromCreatedDto();
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stockModel == null)
        {
            return NotFound();
        }

        stockModel.Symbol = updateStockDto.Symbol;
        stockModel.CompanyName = updateStockDto.CompanyName;
        stockModel.Marketcap = updateStockDto.Marketcap;
        stockModel.Purchace = updateStockDto.Purchace;
        stockModel.Industry = updateStockDto.Industry;
        stockModel.Lastdiv = updateStockDto.Lastdiv;

        await _context.SaveChangesAsync();

        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
        if (stockModel == null)
        {
            return NotFound();
        }

        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}