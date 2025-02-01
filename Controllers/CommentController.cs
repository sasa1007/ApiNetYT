using Api.Data;
using Api.Dtos.Stock;
using Api.Mappers;
using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("/api/comment")]
public class CommentCotrnoller : ControllerBase
{
    private readonly ICommentRepository _commentRepository;

    public CommentCotrnoller(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var comments = await _commentRepository.GetAllSync();

        var commentDto = comments.Select(s => s.ToCommentDto());

        return Ok(commentDto);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById([FromRoute] int id)
    // {
    //     var stock = await _commentRepository.GetByIdAsync(id);
    //
    //     if (stock == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return Ok(stock.ToStockDto());
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> Post([FromBody] CreateStockRequestDto stockDto)
    // {
    //     var stockModel = stockDto.ToStockFromCreatedDto();
    //     await _commentRepository.CreateAsync(stockModel);
    //
    //     return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
    // {
    //     var stockModel = await _commentRepository.UpdateAsync(id, updateStockDto);
    //
    //     if (stockModel == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return Ok(stockModel.ToStockDto());
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete([FromRoute] int id)
    // {
    //     var stockModel = await _commentRepository.DeleteAsync(id);
    //
    //     if (stockModel == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return NoContent();
    // }
}