using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.GetFriendsOfUser
{
    public class GetFriendsOfUserQuery : IRequest<OperationResult<List<UserInfoDto>>>
    {
        public Guid UserId { get; }
        public GetFriendsOfUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
