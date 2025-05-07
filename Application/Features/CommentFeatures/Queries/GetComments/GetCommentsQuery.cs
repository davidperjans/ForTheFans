using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Queries.GetComments
{
    public class GetCommentsQuery : IRequest<OperationResult<List<CommentDto>>>
    {
        public Guid PostId { get; }

        public GetCommentsQuery(Guid postId)
        {
            PostId = postId;
        }
    }
}
