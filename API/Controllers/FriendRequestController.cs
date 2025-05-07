using Application.DTOs;
using Application.Features.FriendRequestFeatures.Commands.AcceptFriendRequest;
using Application.Features.FriendRequestFeatures.Commands.RejectFriendRequest;
using Application.Features.FriendRequestFeatures.Commands.SendFriendRequest;
using Application.Features.FriendRequestFeatures.Queries.GetFriendRequests;
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
    public class FriendRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FriendRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendRequest([FromBody] SendFriendRequestDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var fromUserId))
                return Unauthorized();

            var result = await _mediator.Send(new SendFriendRequestCommand(fromUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("accept")]
        public async Task<IActionResult> AcceptRequest([FromBody] FriendRequestDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new AcceptFriendRequestCommand(currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectRequest([FromBody] FriendRequestDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new RejectFriendRequestCommand(currentUserId, dto));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-requests")]
        public async Task<IActionResult> GetRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var currentUserId))
                return Unauthorized();

            var result = await _mediator.Send(new GetFriendRequestsQuery(currentUserId));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
