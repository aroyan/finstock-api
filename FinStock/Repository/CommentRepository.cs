using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinStock.Data;
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

        public async Task<List<Comment>> GetAllAsync()
        {
            var comments = await _context.Comments.ToListAsync();
            return comments;
        }
    }
}