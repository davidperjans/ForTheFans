using Application.Features.CommentFeatures.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.CommentValidators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Dto.PostId)
                .NotEmpty().WithMessage("PostId is required.");

            RuleFor(x => x.Dto.Content)
                .NotEmpty().WithMessage("Comment content is required.")
                .MaximumLength(500).WithMessage("Comment can't exceed 500 characters.");
        }
    }
}
