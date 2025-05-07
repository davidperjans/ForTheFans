using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendFeatures.Queries.GetFriends
{
    public class GetFriendsQuery : IRequest<OperationResult<List<FriendDto>>>
    {
        public Guid UserId { get; set; }
        public GetFriendsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
