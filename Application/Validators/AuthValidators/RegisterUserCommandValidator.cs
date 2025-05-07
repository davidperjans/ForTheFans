using Application.Features.AuthFeatures.Commands.RegisterUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.AuthValidators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Dto.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Dto.Email)
                .NotEmpty().EmailAddress().WithMessage("Valid email is required.");

            RuleFor(x => x.Dto.Password)
                .NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            RuleFor(x => x.Dto.ConfirmPassword)
                .NotEmpty().Equal(x => x.Dto.Password).WithMessage("Passwords must match.");
        }
    }
}
