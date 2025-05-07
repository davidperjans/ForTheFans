using Application.Features.PostFeatures.Commands.CreatePost;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.PostValidators
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Dto.StadiumId)
                .NotEmpty()
                .WithMessage("Stadium ID is required.");

            RuleFor(x => x.Dto.PhotoUrl)
                .NotEmpty()
                .WithMessage("A photo URL is required.");

            RuleFor(x => x.Dto.Rating)
                .InclusiveBetween(1, 10)
                .WithMessage("Rating must be between 1 and 10.");

            RuleFor(x => x.Dto.HomeTeam)
                .NotEmpty()
                .WithMessage("Home team name is required.");

            RuleFor(x => x.Dto.AwayTeam)
                .NotEmpty()
                .WithMessage("Away team name is required.");

            RuleFor(x => x.Dto.MatchResult)
                .NotEmpty()
                .WithMessage("Match result is required (e.g., 2–1).");

            RuleFor(x => x.Dto.Comment)
                .MaximumLength(1000)
                .WithMessage("Comment cannot exceed 1000 characters.");
        }
    }
}
