using Application.DTOs;
using Application.Features.CommentFeatures.Commands.CreateComment;
using Application.Features.CommentFeatures.Commands.DeleteComment;
using Application.Features.CommentFeatures.Queries.GetComments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new CreateCommentCommand(currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetCommentsForPost(Guid postId)
        {
            var result = await _mediator.Send(new GetCommentsQuery(postId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new DeleteCommentCommand(commentId, currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
