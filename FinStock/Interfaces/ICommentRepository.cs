using FinStock.Dtos.Comment;
using FinStock.Models;

namespace FinStock.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment?> CreateAsync(Comment createCommentDto);
        Task<Comment?> DeleteByIdAsync(int id);
        Task<Comment?> UpdateByIdAsync(int id, UpdateCommentDto updateCommentDto);
    }
}