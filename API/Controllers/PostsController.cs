using Application.DTOs;
using Application.Features.PostFeatures.Commands.CreatePost;
using Application.Features.PostFeatures.Commands.DeletePost;
using Application.Features.PostFeatures.Commands.UpdatePost;
using Application.Features.PostFeatures.Queries.GetFriendsPosts;
using Application.Features.PostFeatures.Queries.GetPostById;
using Application.Features.PostFeatures.Queries.GetPostsByStadiumSlug;
using Application.Features.PostFeatures.Queries.GetPostsByUser;
using Application.Features.PostFeatures.Queries.GetUserPosts;
using Domain.Entities;
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
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new CreatePostCommand(currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetMyPosts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetUserPostsQuery(currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("friends")]
        public async Task<IActionResult> GetFriendsPosts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetFriendsPostsQuery(currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPostByUserId(Guid userId)
        {
            var currentuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(currentuserId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetPostsByUserQuery(userId, currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetPostByIdQuery(postId, currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePostById(Guid postId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new DeletePostCommand(postId, currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{postId}")]
        public async Task<IActionResult> PatchPost(Guid postId, [FromBody] UpdatePostDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new UpdatePostCommand(postId, currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("stadium/slug/{slug}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPostsByStadiumSlug(string slug)
        {
            var result = await _mediator.Send(new GetPostsByStadiumSlugQuery(slug));

            if (!result.IsSuccess || result.Data == null || result.Data.Count == 0)
                return NotFound(result);

            return Ok(result);
        }
    }
}
