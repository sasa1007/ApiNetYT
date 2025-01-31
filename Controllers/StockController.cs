using Api.Data;
using Api.Dtos.Stock;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Get()
    {
        var stocks = _context.Stocks.ToList().Select(s => s.ToStockDto());

        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var stock = _context.Stocks.Find(id);

        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateStockRequestDto stockDto)
    {
        var stockModel = stockDto.ToStockFromCreatedDto();
        _context.Stocks.Add(stockModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
    {
        var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

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

        _context.SaveChanges();

        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
        if (stockModel == null)
        {
            return NotFound();
        }
        _context.Stocks.Remove(stockModel);
        _context.SaveChanges();
        return NoContent();
    }
}