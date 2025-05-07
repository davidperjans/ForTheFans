using Application.Common;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Commands.AcceptFriendRequest
{
    public class AcceptFriendRequestHandler : IRequestHandler<AcceptFriendRequestCommand, OperationResult<bool>>
    {
        private readonly IFriendRepository _friendRepository;
        public AcceptFriendRequestHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public async Task<OperationResult<bool>> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var friendRequest = await _friendRepository.GetFriendRequestByIdAsync(dto.RequestId);
            if (friendRequest == null)
                return OperationResult<bool>.Failure("Friend request not found.");

            if (friendRequest.ToUserId != request.CurrentUserId)
                return OperationResult<bool>.Failure("You are not authorized to accept this friend request.");

            if (friendRequest.Status != RequestStatus.Pending)
                return OperationResult<bool>.Failure("Friend request is not pending.");

            // Update the status of the friend request to Accepted
            friendRequest.Status = RequestStatus.Accepted;
            friendRequest.AcceptedOrRejectedAt = DateTime.UtcNow;

            // Create a new friendship
            var newFriendship = new Friendship
            {
                Id = Guid.NewGuid(),
                User1Id = friendRequest.FromUserId,
                User2Id = friendRequest.ToUserId,
                Since = DateTime.UtcNow,
            };

            await _friendRepository.AddFriendshipAsync(newFriendship);

            return OperationResult<bool>.Success(true);
        }
    }
}
