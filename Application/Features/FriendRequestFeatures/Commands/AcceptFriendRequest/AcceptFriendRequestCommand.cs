using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Commands.AcceptFriendRequest
{
    public class AcceptFriendRequestCommand : IRequest<OperationResult<bool>>
    {
        public Guid CurrentUserId { get; }
        public FriendRequestDto Dto { get; }

        public AcceptFriendRequestCommand(Guid currentUserId, FriendRequestDto dto)
        {
            CurrentUserId = currentUserId;
            Dto = dto;
        }
    }
}
