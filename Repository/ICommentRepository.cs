using Api.Dtos.Stock;
using Api.Models;

namespace Api.Repository;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllSync();

    Task<Comment?> GetByIdAsync(int id);

    Task<Comment> CreateAsync(Comment comment);

    Task<Comment?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

    Task<Comment?> DeleteAsync(int id);
}