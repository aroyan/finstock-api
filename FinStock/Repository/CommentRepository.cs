using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinStock.Data;
using FinStock.Dtos.Comment;
using FinStock.Interfaces;
using FinStock.Models;
using Microsoft.EntityFrameworkCore;

namespace FinStock.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment?> CreateAsync(Comment createCommentDto)
        {
            await _context.Comments.AddAsync(createCommentDto);
            await _context.SaveChangesAsync();
            return createCommentDto;
        }

        public async Task<Comment?> DeleteByIdAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentModel is null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);

            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            var comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment is null)
            {
                return null;
            }

            return comment;
        }

        public async Task<Comment?> UpdateByIdAsync(int id, UpdateCommentDto updateCommentDto)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentModel is null)
            {
                return null;
            }

            commentModel.Content = updateCommentDto.Content;
            commentModel.Title = updateCommentDto.Title;

            await _context.SaveChangesAsync();

            return commentModel;
        }
    }
}