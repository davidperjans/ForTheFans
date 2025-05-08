using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Queries.GetFriendRequests
{
    public class GetFriendRequestsQueryHandler : IRequestHandler<GetFriendRequestsQuery, OperationResult<List<ReceivedFriendRequestDto>>>
    {
        private readonly IFriendRepository _friendRepository;
        public GetFriendRequestsQueryHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public async Task<OperationResult<List<ReceivedFriendRequestDto>>> Handle(GetFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var friendRequests = await _friendRepository.GetRelevantFriendRequestsAsync(request.CurrentUserId);

            var result = friendRequests.Select(fr =>
            {
                var direction = fr.ToUserId == request.CurrentUserId ? "Incoming" : "Outgoing";

                return new ReceivedFriendRequestDto
                {
                    RequestId = fr.Id,
                    FromUserId = fr.FromUserId,
                    FromUsername = fr.FromUser.Username,
                    FromProfilePictureUrl = fr.FromUser.ProfilePictureUrl,
                    toUserId = fr.ToUserId,
                    SentAt = fr.SentAt,
                    Direction = direction,
                };
            }).ToList();

            return OperationResult<List<ReceivedFriendRequestDto>>.Success(result);
        }
    }
}
