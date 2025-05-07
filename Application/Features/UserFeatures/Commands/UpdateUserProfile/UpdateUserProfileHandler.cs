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
        public async Task<OperationResult<bool>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return OperationResult<bool>.Failure("User not found");

            var dto = request.Dto;

            // Check if user wants to change email
            if (!string.IsNullOrWhiteSpace(dto.Email) && dto.Email != user.Email)
            {
                // Check if email is already in use
                var existingEmail = await _authRepository.EmailExistsAsync(dto.Email);
                if (existingEmail)
                    return OperationResult<bool>.Failure("Email is already in use");
                
                user.Email = dto.Email;
            }

            // Check if user wants to change username
            if (!string.IsNullOrWhiteSpace(dto.Username) && dto.Username != user.Username)
            {
                // Check if username is already in use
                var existingUsername = await _authRepository.UsernameExistsAsync(dto.Username);
                if (existingUsername)
                    return OperationResult<bool>.Failure("Username is already in use");

                user.Username = dto.Username;
            }

            // Check if user wants to change favorite team
            if (dto.FavoriteTeam is not null)
                user.FavoriteTeam = dto.FavoriteTeam;

            // Check if user wants to change privacy settings
            if (dto.IsPrivate.HasValue)
                user.IsPrivate = dto.IsPrivate.Value;

            // Check if user wants to change profile picture
            if (dto.ProfilePictureUrl is not null)
                user.ProfilePictureUrl = dto.ProfilePictureUrl;

            await _userRepository.UpdateAsync(user);

            return OperationResult<bool>.Success(true);
        }
    }
}
