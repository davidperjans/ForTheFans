using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FriendRequestFeatures.Commands.SendFriendRequest
{
    public class SendFriendRequestCommand : IRequest<OperationResult<bool>>
    {
        public Guid FromUserId { get; set; }
        public SendFriendRequestDto Dto { get; set; }
        public SendFriendRequestCommand(Guid fromUserId, SendFriendRequestDto dto)
        {
            FromUserId = fromUserId;
            Dto = dto;
        }
    }
}
