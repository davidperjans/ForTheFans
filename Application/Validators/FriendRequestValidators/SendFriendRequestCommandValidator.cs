using Application.Features.FriendRequestFeatures.Commands.SendFriendRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.FriendRequestValidators
{
    public class SendFriendRequestCommandValidator : AbstractValidator<SendFriendRequestCommand>
    {
        public SendFriendRequestCommandValidator()
        {
            RuleFor(x => x.Dto.ToUserId)
                .NotEmpty().WithMessage("Recipient user ID is required.");
        }
    }
}
