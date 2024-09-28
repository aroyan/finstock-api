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
                StockId = commentModel.StockId
            };
        }

        // public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        // {
        //     return new Stock
        //     {
        //         CompanyName = stockDto.CompanyName,
        //         Industry = stockDto.Industry,
        //         LastDiv = stockDto.LastDiv,
        //         MarketCap = stockDto.MarketCap,
        //         Purchase = stockDto.Purchase,
        //         Symbol = stockDto.Symbol
        //     };
        // }
    }
}