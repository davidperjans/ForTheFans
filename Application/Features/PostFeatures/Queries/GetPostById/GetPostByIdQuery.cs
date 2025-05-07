using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<OperationResult<PostDto>>
    {
        public Guid PostId { get; set; }
        public Guid CurrentUserId { get; set; }
        public GetPostByIdQuery(Guid postId, Guid currentUserId)
        {
            PostId = postId;
            CurrentUserId = currentUserId;
        }
    }
}
