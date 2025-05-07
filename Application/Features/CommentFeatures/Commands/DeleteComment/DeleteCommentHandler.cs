using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, OperationResult<bool>>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.CommentId);
            if (comment == null)
                return OperationResult<bool>.Failure("Comment not found.");

            if (comment.UserId != request.CurrentUserId)
                return OperationResult<bool>.Failure("You are not authorized to delete this comment.");

            await _commentRepository.DeleteAsync(request.CommentId);

            return OperationResult<bool>.Success(true);
        }
    }
}
