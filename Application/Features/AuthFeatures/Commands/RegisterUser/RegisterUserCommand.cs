using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<OperationResult<UserDto>>
    {
        public RegisterUserDto Dto { get; }

        public RegisterUserCommand(RegisterUserDto dto)
        {
            Dto = dto;
        }
    }
}
