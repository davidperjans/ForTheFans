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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, OperationResult<UserDto>>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public RegisterUserHandler(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (await _authRepository.EmailExistsAsync(dto.Email))
                return OperationResult<UserDto>.Failure("Email already exists");

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

            var resultDto = _mapper.Map<UserDto>(newUser);
            return OperationResult<UserDto>.Success(resultDto);
        }
    }
}
