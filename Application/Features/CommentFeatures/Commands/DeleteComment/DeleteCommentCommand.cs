using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<OperationResult<bool>>
    {
        public Guid CommentId { get; }
        public Guid CurrentUserId { get; }

        public DeleteCommentCommand(Guid commentId, Guid currentUserId)
        {
            CommentId = commentId;
            CurrentUserId = currentUserId;
        }
    }
}
