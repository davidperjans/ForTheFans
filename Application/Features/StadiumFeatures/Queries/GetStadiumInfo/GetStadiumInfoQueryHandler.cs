using Application.Common;
using Application.Common.Responses;
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StadiumFeatures.Queries.GetStadiumInfo
{
    public class GetStadiumInfoQueryHandler : IRequestHandler<GetStadiumInfoQuery, OperationResult<List<StadiumDto>>>
    {
        private readonly IStadiumInfoService _stadiumService;
        public GetStadiumInfoQueryHandler(IStadiumInfoService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        public async Task<OperationResult<List<StadiumDto>>> Handle(GetStadiumInfoQuery request, CancellationToken cancellationToken)
        {
            var stadium = await _stadiumService.GetStadiumInfoAsync(request.StadiumName);

            if (stadium == null)
                return OperationResult<List<StadiumDto>>.Failure("Ingen arena hittades");

            return OperationResult<List<StadiumDto>>.Success(stadium);
        }
    }
}
