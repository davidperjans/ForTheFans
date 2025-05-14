using Application.Common;
using Application.Common.Responses;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StadiumFeatures.Queries.GetStadiumInfo
{
    public class GetStadiumInfoQuery : IRequest<OperationResult<List<StadiumDto>>>
    {
        public string StadiumName { get; set; }
        public GetStadiumInfoQuery(string stadiumName)
        {
            StadiumName = stadiumName;
        }
    }
}
