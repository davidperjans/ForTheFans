using Application.Features.FriendFeatures.Commands.RemoveFriend;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.FriendValidators
{
    public class RemoveFriendCommandValidator : AbstractValidator<RemoveFriendCommand>
    {
        public RemoveFriendCommandValidator()
        {
            RuleFor(x => x.FriendId)
                .NotEmpty().WithMessage("Friend ID is required.");
        }
    }
}
