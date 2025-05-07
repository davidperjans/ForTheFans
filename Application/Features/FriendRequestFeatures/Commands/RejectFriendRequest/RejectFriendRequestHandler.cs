using Application.Common;
using Application.Interfaces;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Commands.RejectFriendRequest
{
    public class RejectFriendRequestHandler : IRequestHandler<RejectFriendRequestCommand, OperationResult<bool>>
    {
        private readonly IFriendRepository _friendRepository;
        public RejectFriendRequestHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public async Task<OperationResult<bool>> Handle(RejectFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var friendRequest = await _friendRepository.GetFriendRequestByIdAsync(dto.RequestId);
            if (friendRequest == null)
                return OperationResult<bool>.Failure("Friend request not found.");

            if (friendRequest.ToUserId != request.CurrentUserId)
                return OperationResult<bool>.Failure("You are not authorized to reject this friend request.");

            if (friendRequest.Status != RequestStatus.Pending)
                return OperationResult<bool>.Failure("Friend request is not pending.");

            // Update the status of the friend request to Rejected
            friendRequest.Status = RequestStatus.Rejected;
            friendRequest.AcceptedOrRejectedAt = DateTime.UtcNow;

            return OperationResult<bool>.Success(true);
        }
    }
}
