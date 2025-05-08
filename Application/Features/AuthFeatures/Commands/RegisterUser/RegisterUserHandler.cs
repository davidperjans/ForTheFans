using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, OperationResult<AuthResultDto>>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenService _tokenService;
        private readonly IMapper _mapper;
        public RegisterUserHandler(IAuthRepository authRepository, IJwtTokenService tokenService, IMapper mapper)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<OperationResult<AuthResultDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (await _authRepository.EmailExistsAsync(dto.Email))
                return OperationResult<AuthResultDto>.Failure("Email already exists");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                CreatedAt = DateTime.UtcNow,
            };

            await _authRepository.AddUserAsync(newUser);

            var token = _tokenService.GenerateJwtToken(newUser);

            var authResult = new AuthResultDto
            {
                Token = token,
                Username = newUser.Username
            };

            return OperationResult<AuthResultDto>.Success(authResult);
        }
    }
}
