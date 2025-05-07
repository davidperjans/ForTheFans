using Application.Features.FriendFeatures.Commands.RemoveFriend;
using Application.Features.FriendFeatures.Queries.GetFriends;
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
    public class FriendsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FriendsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFriends()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetFriendsQuery(currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{friendId}")]
        public async Task<IActionResult> RemoveFriend(Guid friendId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new RemoveFriendCommand(currentUserId, friendId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
