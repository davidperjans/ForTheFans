using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendFeatures.Commands.RemoveFriend
{
    public class RemoveFriendCommand : IRequest<OperationResult<bool>>
    {
        public Guid CurrentUserId { get; }
        public Guid FriendId { get; }

        public RemoveFriendCommand(Guid currentUserId, Guid friendId)
        {
            CurrentUserId = currentUserId;
            FriendId = friendId;
        }
    }
}
