using Application.Features.UserFeatures.Commands.UpdateUserProfile;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.UserValidators
{
    public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(x => x.Dto.Username)
                .MaximumLength(50)
                .When(x => x.Dto.Username is not null);

            RuleFor(x => x.Dto.Email)
                .EmailAddress()
                .When(x => x.Dto.Email is not null);

            RuleFor(x => x.Dto.FavoriteTeam)
                .MaximumLength(50)
                .When(x => x.Dto.FavoriteTeam is not null);
        }
    }
}
