using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Queries.GetFriendRequests
{
    public class GetFriendRequestsQuery : IRequest<OperationResult<List<ReceivedFriendRequestDto>>>
    {
        public Guid CurrentUserId { get; set; }
        public GetFriendRequestsQuery(Guid currentUserId)
        {
            CurrentUserId = currentUserId;
        }
    }
}
