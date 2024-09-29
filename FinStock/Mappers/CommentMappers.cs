using FinStock.Dtos.Comment;
using FinStock.Models;

namespace FinStock.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                StockId = commentModel.StockId,
                CreatedAt = commentModel.CreatedAt
            };
        }

        // TODO: get the stockId from route param
        public static Comment ToCommentFromCreateDTO(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {
                Content = commentDto.Content,
                Title = commentDto.Title,
                StockId = stockId
            };
        }
    }
}