using Application.DTOs;
using Application.Features.UserFeatures.Commands;
using Application.Features.UserFeatures.Commands.ChangePassword;
using Application.Features.UserFeatures.Commands.UpdateUserProfile;
using Application.Features.UserFeatures.Queries.GetCurrentUser;
using Application.Features.UserFeatures.Queries.GetFriendsOfUser;
using Application.Features.UserFeatures.Queries.GetUserById;
using Application.Features.UserFeatures.Queries.SearchUsers;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new SearchUsersQuery(query, currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new UpdateUserProfileCommand(currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new ChangePasswordCommand(currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetCurrentUserQuery(currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}/friends")]
        public async Task<IActionResult> GetFriendsOfUser(Guid id)
        {

            var result = await _mediator.Send(new GetFriendsOfUserQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId));

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
