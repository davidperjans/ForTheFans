using Application.Features.PostFeatures.Commands.UpdatePost;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.PostValidators
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(x => x.Dto.Rating)
                .InclusiveBetween(1, 10)
                .When(x => x.Dto.Rating.HasValue)
                .WithMessage("Rating must be between 1 and 10.");

            RuleFor(x => x.Dto.Comment)
                .MaximumLength(1000)
                .When(x => x.Dto.Comment != null)
                .WithMessage("Comment cannot exceed 1000 characters.");
        }
    }
}
