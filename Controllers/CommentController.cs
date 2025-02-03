using Api.Data;
using Api.Dtos.Comment;
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
    private readonly IStockRepository _stockRepository;

    public CommentCotrnoller(ICommentRepository commentRepository, IStockRepository stockRepository)
    {
        _commentRepository = commentRepository;
        _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var comments = await _commentRepository.GetAllSync();

        var commentDto = comments.Select(s => s.ToCommentDto());

        return Ok(commentDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment.ToCommentDto());
    }

    [HttpPost("{stockId}")]
    public async Task<IActionResult> Post([FromRoute] int stockId, CreateCommentDto createCommentDto)
    {
        if (!await _stockRepository.StockExists((stockId)))
        {
            return BadRequest("Stock not found");
        }

        var commentModel = createCommentDto.ToCommentFromCreate(stockId);
        await _commentRepository.CreateAsync(commentModel);

        return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());

    }
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