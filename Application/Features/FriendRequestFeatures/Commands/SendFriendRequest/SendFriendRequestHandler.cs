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

namespace Application.Features.FriendRequestFeatures.Commands.SendFriendRequest
{
    public class SendFriendRequestHandler : IRequestHandler<SendFriendRequestCommand, OperationResult<bool>>
    {
        private readonly IFriendRepository _friendRepository;
        public SendFriendRequestHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public async Task<OperationResult<bool>> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (request.FromUserId == dto.ToUserId)
                return OperationResult<bool>.Failure("You cannot send a friend request to yourself");

            var alreadySent = await _friendRepository.FriendRequestExistsAsync(request.FromUserId, dto.ToUserId);
            if (alreadySent)
                return OperationResult<bool>.Failure("A friend request already exists between these users");

            var alreadyFriends = await _friendRepository.AreUsersAlreadyFriendsAsync(request.FromUserId, dto.ToUserId);
            if (alreadyFriends)
                return OperationResult<bool>.Failure("You are already friends with this user");

            var newRequest = new FriendRequest
            {
                Id = Guid.NewGuid(),
                FromUserId = request.FromUserId,
                ToUserId = dto.ToUserId,
                Status = RequestStatus.Pending,
                SentAt = DateTime.UtcNow,
            };

            await _friendRepository.AddFriendRequestAsync(newRequest);

            return OperationResult<bool>.Success(true);
        }
    }
}
