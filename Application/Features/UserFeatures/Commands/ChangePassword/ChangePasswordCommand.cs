using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<OperationResult<bool>>
    {
        public Guid UserId { get; }
        public ChangePasswordDto Dto { get; }
        public ChangePasswordCommand(Guid userId, ChangePasswordDto dto)
        {
            UserId = userId;
            Dto = dto;
        }
    }
}
