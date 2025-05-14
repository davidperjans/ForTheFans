using Application.Features.StadiumFeatures.Queries.GetStadiumInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StadiumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{stadiumName}")]
        public async Task<IActionResult> GetStadiumInfo(string stadiumName)
        {
            var result = await _mediator.Send(new GetStadiumInfoQuery(stadiumName));

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
