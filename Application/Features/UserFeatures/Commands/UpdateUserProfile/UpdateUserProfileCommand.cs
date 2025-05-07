using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<OperationResult<bool>>
    {
        public Guid UserId { get; }
        public UpdateUserProfileDto Dto { get; }
        public UpdateUserProfileCommand(Guid userId, UpdateUserProfileDto dto)
        {
            UserId = userId;
            Dto = dto;
        }
    }
}
