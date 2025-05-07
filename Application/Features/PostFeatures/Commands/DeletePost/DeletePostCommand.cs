using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<OperationResult<bool>>
    {
        public Guid PostId { get; set; }
        public Guid CurrentUserId { get; set; }
        public DeletePostCommand(Guid postId, Guid currentUserId)
        {
            PostId = postId;
            CurrentUserId = currentUserId;
        }
    }
}
