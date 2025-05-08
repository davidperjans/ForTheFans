using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.UpdateUserProfile
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, OperationResult<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        public UpdateUserProfileHandler(IUserRepository userRepository, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        public async Task<OperationResult<bool>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return OperationResult<bool>.Failure("User not found");

            var dto = request.Dto;
            bool isModified = false;

            // Check if user wants to change email
            if (!string.IsNullOrWhiteSpace(dto.Email) && dto.Email != user.Email)
            {
                // Check if email is already in use
                var existingEmail = await _authRepository.EmailExistsAsync(dto.Email);
                if (existingEmail)
                    return OperationResult<bool>.Failure("Email is already in use");
                
                user.Email = dto.Email;
                isModified = true;
            }

            // Check if user wants to change username
            if (!string.IsNullOrWhiteSpace(dto.Username) && dto.Username != user.Username)
            {
                // Check if username is already in use
                var existingUsername = await _authRepository.UsernameExistsAsync(dto.Username);
                if (existingUsername)
                    return OperationResult<bool>.Failure("Username is already in use");

                user.Username = dto.Username;
                isModified = true;
            }

            if (dto.FavoriteTeam is not null && dto.FavoriteTeam != user.FavoriteTeam)
            {
                user.FavoriteTeam = dto.FavoriteTeam;
                isModified = true;
            }

            if (dto.IsPrivate.HasValue && dto.IsPrivate.Value != user.IsPrivate)
            {
                user.IsPrivate = dto.IsPrivate.Value;
                isModified = true;
            }

            if (dto.ProfilePictureUrl is not null && dto.ProfilePictureUrl != user.ProfilePictureUrl)
            {
                user.ProfilePictureUrl = dto.ProfilePictureUrl;
                isModified = true;
            }

            if (isModified)
            {
                user.UpdatedAt = DateTime.UtcNow;
                await _userRepository.UpdateAsync(user);
            }

            return OperationResult<bool>.Success(isModified);
        }
    }
}
