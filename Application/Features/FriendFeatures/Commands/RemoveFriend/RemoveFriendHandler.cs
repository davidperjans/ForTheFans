using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendFeatures.Commands.RemoveFriend
{
    public class RemoveFriendHandler : IRequestHandler<RemoveFriendCommand, OperationResult<bool>>
    {
        private readonly IFriendRepository _friendRepository;

        public RemoveFriendHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<OperationResult<bool>> Handle(RemoveFriendCommand request, CancellationToken cancellationToken)
        {
            var friendship = await _friendRepository.GetFriendshipAsync(request.CurrentUserId, request.FriendId);

            if (friendship == null)
                return OperationResult<bool>.Failure("Friendship not found.");

            await _friendRepository.RemoveFriendshipAsync(friendship);

            return OperationResult<bool>.Success(true);
        }
    }
}
