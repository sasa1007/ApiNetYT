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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var comment = await _commentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment.ToCommentDto());
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Post([FromRoute] int stockId, CreateCommentDto createCommentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (!await _stockRepository.StockExists((stockId)))
        {
            return BadRequest("Stock not found");
        }

        var commentModel = createCommentDto.ToCommentFromCreate(stockId);
        await _commentRepository.CreateAsync(commentModel);

        return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto  updateCommentRequestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var comment = await _commentRepository.UpdateAsync(id, updateCommentRequestDto.ToCommentFromUpdate());

        if (comment == null)
        {
            return NotFound("Comment not found");
        }

        return Ok(comment.ToCommentDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var commentFromDb = await _commentRepository.DeleteAsync(id);

        if (commentFromDb == null)
        {
            return NotFound();
        }

        return Ok(commentFromDb);
    }
}