using Api.Data;
using Api.Dtos.Stock;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class CommentRepository : ICommentRepository

{
    private readonly AplicationDbContext _context;

    public CommentRepository(AplicationDbContext aplicationDbContext)
    {
        _context = aplicationDbContext;
    }

    public async Task<List<Comment>> GetAllSync()
    {
        return await _context.Comments.ToListAsync();
    }

    public Task<Comment?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> CreateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}