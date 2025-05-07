using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, OperationResult<bool>>
    {
        private readonly IUserRepository _userRepository;
        public ChangePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<OperationResult<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return OperationResult<bool>.Failure("User not found");

            var dto = request.Dto;

            // Verify the current password
            if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash))
                return OperationResult<bool>.Failure("Current password is incorrect");

            // Hash the new password and save it
            var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.PasswordHash = newPasswordHash;

            await _userRepository.UpdateAsync(user);

            return OperationResult<bool>.Success(true);
        }
    }
}
