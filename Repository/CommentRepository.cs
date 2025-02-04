using Api.Data;
using Api.Dtos.Stock;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment comment)
    {
        var commentFromDB = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

        if (commentFromDB == null)
        {
            return null;
        }

        commentFromDB.Title = comment.Title;
        commentFromDB.Content = comment.Content;

        await _context.SaveChangesAsync();
        return commentFromDB;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var  commentFromDB = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

        if (commentFromDB == null)
        {
            return null;
        }
        _context.Comments.Remove(commentFromDB);
        await _context.SaveChangesAsync();
        return commentFromDB;
    }
}