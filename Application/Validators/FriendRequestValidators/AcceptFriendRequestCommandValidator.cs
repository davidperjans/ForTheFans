using Application.Features.FriendRequestFeatures.Commands.AcceptFriendRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.FriendRequestValidators
{
    public class AcceptFriendRequestCommandValidator : AbstractValidator<AcceptFriendRequestCommand>
    {
        public AcceptFriendRequestCommandValidator()
        {
            RuleFor(x => x.Dto.RequestId).NotEmpty().WithMessage("Friend request ID is required.");
        }
    }
}
