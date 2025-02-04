using Api.Dtos.Comment;
using Api.Models;

namespace Api.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            StockId = comment.StockId,
        };
    }

    public static Comment ToCommentFromCreate(this CreateCommentDto createCommentDto, int stockId)
    {
        return new Comment
        {
            Title = createCommentDto.Title,
            Content = createCommentDto.Content,
            StockId = stockId
        };
    }

    public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto updateCommentRequestDto)
    {
        return new Comment
        {
            Title = updateCommentRequestDto.Title,
            Content = updateCommentRequestDto.Content,

        };
    }
}