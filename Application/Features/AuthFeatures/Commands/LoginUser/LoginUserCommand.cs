using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthFeatures.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<OperationResult<AuthResultDto>>
    {
        public LoginUserDto Dto { get; set; }
        public LoginUserCommand(LoginUserDto dto)
        {
            Dto = dto;
        }
    }
}
