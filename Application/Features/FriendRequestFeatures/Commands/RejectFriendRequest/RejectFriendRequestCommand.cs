using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Commands.RejectFriendRequest
{
    public class RejectFriendRequestCommand : IRequest<OperationResult<bool>>
    {
        public Guid CurrentUserId { get; }
        public FriendRequestDto Dto { get; }
        public RejectFriendRequestCommand(Guid currentUserId, FriendRequestDto dto)
        {
            CurrentUserId = currentUserId;
            Dto = dto;
        }
    }
}
