using FinStock.Dtos.Comment;
using FinStock.Interfaces;
using FinStock.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinStock.Controllers
{
    [ApiController]
    [Route("api/comment")]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto createCommentDto)
        {
            if (!await _stockRepository.StockExist(stockId))
            {
                return BadRequest("Stock does not exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentModel = createCommentDto.ToCommentFromCreateDTO(stockId);
            await _commentRepository.CreateAsync(commentModel);
            return Ok(commentModel.ToCommentDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment is null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            var comment = await _commentRepository.DeleteByIdAsync(id);

            if (comment is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepository.UpdateByIdAsync(id, updateCommentDto);

            if (comment is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(comment.ToCommentDto());
        }
    }
}