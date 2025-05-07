using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.GetCurrentUser
{
    public class GetCurrentUserQuery : IRequest<OperationResult<MeDto>>
    {
        public Guid UserId { get; }
        public GetCurrentUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
