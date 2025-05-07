using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthFeatures.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, OperationResult<AuthResultDto>>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenService _tokenService;

        public LoginUserHandler(IAuthRepository authRepository, IJwtTokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }
        public async Task<OperationResult<AuthResultDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var user = await _authRepository.GetUserByEmailAsync(dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return OperationResult<AuthResultDto>.Failure("Invalid email or password");

            var token = _tokenService.GenerateJwtToken(user);

            var authResult = new AuthResultDto
            {
                Token = token,
                Username = user.Username
            };

            return OperationResult<AuthResultDto>.Success(authResult);
        }
    }
}
